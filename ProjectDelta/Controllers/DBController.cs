using Newtonsoft.Json;
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
using System.Threading.Tasks;
using xNet;

namespace ProjectDelta.Controllers
{
    internal class DBController
    {
        public static Dictionary<string, SteamGuardAccount> PlayingAccounts = new Dictionary<string, SteamGuardAccount>();
        public static Dictionary<string, SteamGuardAccount> BufferAccounts = new Dictionary<string, SteamGuardAccount>();
        public static Dictionary<string, SteamGuardAccount> MarketAccounts = new Dictionary<string, SteamGuardAccount>();

        private static readonly string MA_FILES_PASSKEY = B64X.Encrypt("Qwertyzxc321678");
        private static readonly string ENCRYPTION_KEY_PATH = B64X.Encrypt("TranslationProperties.dll");
        private static readonly string DB_FILE_PATH = "deltaDB.json";
        private const string URL_FOR_GETTING_LAST_DB_FROM_SERVER = "http://a116901.hostde27.fornex.host/delta/license/retrieveSyncDB.php";
        private const string URL_FOR_SENDING_DB_TO_SERVER = "http://a116901.hostde27.fornex.host/delta/license/insertSyncDB.php";
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
                ManifestSteamAccountsController.Manifest = ManifestSteamAccountsController.GetManifest();
                Dictionary<string, SteamGuardAccount> allAccounts = ManifestSteamAccountsController.Manifest.GetAllAccounts(B64X.Decrypt(MA_FILES_PASSKEY));


                return true;
            }
            catch
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
                    MarketAccounts = DBController.MarketAccounts

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
