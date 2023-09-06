﻿using Newtonsoft.Json;
using ProjectDelta.Forms;
using ProjectDelta.Models;
using ProjectDelta.Tools;
using SteamAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using xNet;

namespace ProjectDelta.Controllers
{
    internal class DBController
    {
        public static Dictionary<string, SteamGuardAccount> PlayingAccounts = new Dictionary<string, SteamGuardAccount>();
        public static Dictionary<string, SteamGuardAccount> BufferAccounts = new Dictionary<string, SteamGuardAccount>();
        public static Dictionary<string, SteamGuardAccount> MarketAccounts = new Dictionary<string, SteamGuardAccount>();
        public static List<string> PlayingAccountsSteamIDs = new List<string>();
        public static List<string> MarketAccountsSteamIDs = new List<string>();

        internal static readonly string MA_FILES_PASSKEY = B64X.Encrypt("Qwertyzxc321678");
        private static readonly string ENCRYPTION_KEY_PATH = B64X.Encrypt("TranslationProperties.dll");
        private static readonly string DB_FILE_PATH = "deltaDB.json";
        private static readonly int SAVE_REFRESH_RATE_MS = 1000;
        private const string URL_FOR_GETTING_LAST_DB_FROM_SERVER = "http://a116901.hostde27.fornex.host/delta/license/retrieveSyncDB.php";
        private const string URL_FOR_SENDING_DB_TO_SERVER = "http://a116901.hostde27.fornex.host/delta/license/insertSyncDB.php";
        private static string OldDBString = "";
        private static byte[] EncryptionKey;
        private static byte[] EncryptionIV;

        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            DateFormatHandling = DateFormatHandling.IsoDateFormat,
            DateTimeZoneHandling = DateTimeZoneHandling.Utc
        };


        public static void CreateKeys()
        {
            File.WriteAllText(B64X.Decrypt(ENCRYPTION_KEY_PATH), Convert.ToBase64String(AesGcm256.NewKey()) + Environment.NewLine);
            File.AppendAllText(B64X.Decrypt(ENCRYPTION_KEY_PATH), Convert.ToBase64String(AesGcm256.NewIv()));
        }

        public static void SaveWithCheck()
        {
            while (true)
            {
                string newDBString = GenerateDataForSaving();
                if (newDBString != OldDBString)
                {
                    SaveJSON();
                    OldDBString = newDBString;
                }

                Thread.Sleep(SAVE_REFRESH_RATE_MS);
            }
        }

        public static bool SaveJSON()
        {
            try
            {
                var json = GenerateDataForSaving();
                if (json == "-1") return false;
                File.WriteAllText(DB_FILE_PATH, AesGcm256.encrypt(json, EncryptionKey, EncryptionIV));

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string GetDataForLoading()
        {
            try
            {
                return B64X.Encrypt(AesGcm256.decrypt(File.ReadAllText(DB_FILE_PATH), EncryptionKey, EncryptionIV));
            }
            catch
            {
                return "-1";
            }
        }
        public static bool LoadData()
        {
            try
            {
                string data = GetDataForLoading();
                if (data == "-1") return false;
                
                DatabaseModel deserialized = JsonConvert.DeserializeObject<DatabaseModel>(B64X.Decrypt(data));

                PlayingAccounts = deserialized.PlayingAccounts;
                BufferAccounts = deserialized.BufferAccounts;
                MarketAccounts = deserialized.MarketAccounts;
                PlayingAccountsSteamIDs = deserialized.PlayingAccountsSteamIDs;
                MarketAccountsSteamIDs = deserialized.MarketAccountsSteamIDs;

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool LoadSteamAccountsData()
        {
            try
            {
                ManifestSDAController manifest = ManifestSDAController.GetManifest();
                Dictionary<string, SteamGuardAccount> allAccounts = manifest.GetAllAccounts(B64X.Decrypt(MA_FILES_PASSKEY));

                foreach (var account in allAccounts)
                {
                    if (PlayingAccountsSteamIDs.Contains(account.Key))
                    {
                        PlayingAccounts.Add(account.Key, allAccounts[account.Key]);
                    }
                    else
                    if (MarketAccountsSteamIDs.Contains(account.Key))
                    {
                        MarketAccounts.Add(account.Key, allAccounts[account.Key]);
                    }
                    else
                    {
                        BufferAccounts.Add(account.Key, allAccounts[account.Key]);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GenerateDataForSaving()
        {
            try
            {
                DatabaseModel model = new DatabaseModel()
                {
                    PlayingAccounts = DBController.PlayingAccounts,
                    BufferAccounts = DBController.BufferAccounts,
                    MarketAccounts = DBController.MarketAccounts,
                    PlayingAccountsSteamIDs = DBController.PlayingAccountsSteamIDs,
                    MarketAccountsSteamIDs = DBController.MarketAccountsSteamIDs
                };

                var jsonData = AesGcm256.encrypt(JsonConvert.SerializeObject(model, _jsonSerializerSettings), EncryptionKey, EncryptionIV);

                return jsonData;
            }
            catch
            {
                return "-1";
            }
        }
        public static bool SaveData()
        {
            try
            {
                var jsonData = GenerateDataForSaving();
                if (jsonData == "-1") return false;

                File.WriteAllText(DB_FILE_PATH, jsonData);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool GetEncryptionKey()
        {
            if (!File.Exists(DB_FILE_PATH)) File.WriteAllText(DB_FILE_PATH, "");
            if (!File.Exists(B64X.Decrypt(ENCRYPTION_KEY_PATH)) || !File.Exists(DB_FILE_PATH)) return false;

            var lines = File.ReadAllLines(B64X.Decrypt(ENCRYPTION_KEY_PATH));

            if (lines.Length != 2) return false;

            var key = Convert.FromBase64String(lines[0]);
            var iv = Convert.FromBase64String(lines[1]);

            if (key.Length != AesGcm256.KeyBitSize / 8 && iv.Length != AesGcm256.NonceBitSize / 8) return false;

            EncryptionKey = key;
            EncryptionIV = iv;

            return true;
        }

        public static string SendDBToServer(string dbText, string url = URL_FOR_SENDING_DB_TO_SERVER)
        {
            try
            {
                using (var request = new HttpRequest())
                {
                    request.ConnectTimeout = 5000;

                    var reqParams = new RequestParams();
                    reqParams["db"] = dbText;
                    reqParams["owner"] = ID.NewIDNumber;

                    string response = request.Post(url, reqParams).ToString();
                    return response;
                }
            }
            catch { return "-1"; }
        }

        public static string GetLastDBFromServer(string url = URL_FOR_GETTING_LAST_DB_FROM_SERVER)
        {
            try
            {
                using (var request = new HttpRequest())
                {
                    request.ConnectTimeout = 5000;

                    string response = request.Get(url).ToString();
                    return response;
                }
            }
            catch { return "-1"; }
        }
    }
}
