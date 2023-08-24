using Newtonsoft.Json;
using ProjectDelta.Forms;
using ProjectDelta.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using xNet;

namespace ProjectDelta.Controllers
{
    internal class DBController
    {
        private static readonly string ENCRYPTION_KEY_PATH = B64X.Encrypt("TranslationProperties.dll");
        private static readonly string DB_FILE_PATH = "deltaDB.json";
        private static byte[] EncryptionKey;
        private static byte[] EncryptionIV;

        public static readonly string URL_FOR_GETTING_LAST_DB_FROM_SERVER = "http://a116901.hostde27.fornex.host/delta/license/retrieveSyncDB.php";
        public static readonly string URL_FOR_SENDING_DB_TO_SERVER = "http://a116901.hostde27.fornex.host/delta/license/insertSyncDB.php";

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
                
                /*JSON_DBModel deserialized = JsonConvert.DeserializeObject<JSON_DBModel>(B64X.Decrypt(data));

                MainForm.dataSourceAccounts = new SortableBindingList<Account>(deserialized.Accounts);
                MainForm.dataSourceItems = new SortableBindingList<Item>(deserialized.Items);
                MainForm.dataSourceServers = new SortableBindingList<Server>(deserialized.Servers);
                MainForm.dataSourceProxies = new SortableBindingList<Proxy>(deserialized.Proxies);
                MainForm.dataSourceOutputs = new SortableBindingList<Output>(deserialized.Outputs);*/

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
                /*JSON_DBModel model = new JSON_DBModel()
                {
                    Accounts = MainForm.dataSourceAccounts.ToList(),
                    Items = MainForm.dataSourceItems.ToList(),
                    Servers = MainForm.dataSourceServers.ToList(),
                    Proxies = MainForm.dataSourceProxies.ToList(),
                    Outputs = MainForm.dataSourceOutputs.ToList()
                };

                var jsonData = AesGcm256.encrypt(JsonConvert.SerializeObject(model, _jsonSerializerSettings), EncryptionKey, EncryptionIV);

                return jsonData;*/
                return "";
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

        public static string SendDBToServer(string url, string dbText)
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

        public static string GetLastDBFromServer(string url)
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
