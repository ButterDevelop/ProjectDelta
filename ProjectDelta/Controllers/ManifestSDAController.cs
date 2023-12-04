using Newtonsoft.Json;
using SteamAuth;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDelta.Controllers
{
    internal class ManifestEntry
    {
        [JsonProperty("encryption_iv")]
        public string IV { get; set; }

        [JsonProperty("encryption_salt")]
        public string Salt { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("steamid")]
        public ulong SteamID { get; set; }
    }

    internal class ManifestSDAController
    {
        [JsonProperty("encrypted")]
        public bool Encrypted { get; set; }

        [JsonProperty("first_run")]
        public bool FirstRun { get; set; } = true;

        [JsonProperty("entries")]
        public List<ManifestEntry> Entries { get; set; }

        [JsonProperty("periodic_checking")]
        public bool PeriodicChecking { get; set; } = false;

        [JsonProperty("periodic_checking_interval")]
        public int PeriodicCheckingInterval { get; set; } = 5;

        [JsonProperty("periodic_checking_checkall")]
        public bool CheckAllAccounts { get; set; } = false;

        [JsonProperty("auto_confirm_market_transactions")]
        public bool AutoConfirmMarketTransactions { get; set; } = false;

        [JsonProperty("auto_confirm_trades")]
        public bool AutoConfirmTrades { get; set; } = false;


        public static ManifestSDAController Manifest { get; set; }

        private static string GetManifestDir()
        {
            return Properties.Settings.Default.MAFilesPath;
        }

        public Dictionary<string, SteamGuardAccount> GetAllAccounts(string passKey = null, int limit = -1)
        {
            if (passKey == null && this.Encrypted) return null;
            string maDir = GetManifestDir();

            Dictionary<string, SteamGuardAccount> accounts = new Dictionary<string, SteamGuardAccount>();
            foreach (var entry in this.Entries)
            {
                string fileText = File.ReadAllText(Path.Combine(maDir, entry.Filename));
                if (this.Encrypted)
                { 
                    string decryptedText = FileEncryptor.DecryptData(passKey, entry.Salt, entry.IV, fileText);
                    if (decryptedText == null) return null;
                    fileText = decryptedText;
                }

                var account = JsonConvert.DeserializeObject<SteamGuardAccount>(fileText);
                if (account == null) continue;
                accounts.Add(entry.SteamID.ToString(), account);

                if (limit != -1 && limit >= accounts.Count)
                    break;
            }

            return accounts;
        }

        public static ManifestSDAController GetManifest(bool forceLoad = false)
        {
            // Check if already staticly loaded
            if (Manifest != null && !forceLoad)
            {
                return Manifest;
            }

            // Find config dir and manifest file
            string maDir = GetManifestDir();
            string maFile = Path.Combine(maDir, ConstantsController.MA_MANIFEST_FILE_NAME);

            // If there's no config dir, than we can't continue
            if (!Directory.Exists(maDir)) return null;
            // If there's no manifest, than we can't continue
            if (!File.Exists(maFile)) return null;

            try
            {
                string manifestContents = File.ReadAllText(maFile);
                Manifest = JsonConvert.DeserializeObject<ManifestSDAController>(manifestContents);

                return Manifest;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool VerifyPasskey(string passkey)
        {
            if (!this.Encrypted || this.Entries.Count == 0) return true;

            var accounts = this.GetAllAccounts(passkey, 1);
            return accounts != null && accounts.Count == 1;
        }

        public bool RemoveAccount(SteamGuardAccount account, bool deleteMaFile = true)
        {
            ManifestEntry entry = (from e in this.Entries where e.SteamID == account.Session.SteamID select e).FirstOrDefault();
            if (entry == null) return true; // If something never existed, did you do what they asked?

            string maDir = GetManifestDir();
            string filename = Path.Combine(maDir, entry.Filename);
            this.Entries.Remove(entry);

            if (this.Entries.Count == 0)
            {
                this.Encrypted = false;
            }

            if (this.Save() && deleteMaFile)
            {
                try
                {
                    File.Delete(filename);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            return false;
        }

        public bool SaveAccount(SteamGuardAccount account, bool encrypt, string passKey = null)
        {
            if (encrypt && string.IsNullOrEmpty(passKey)) return false;
            if (!encrypt && this.Encrypted) return false;

            string salt = null;
            string iV = null;
            string jsonAccount = JsonConvert.SerializeObject(account);

            if (encrypt)
            {
                salt = FileEncryptor.GetRandomSalt();
                iV = FileEncryptor.GetInitializationVector();
                string encrypted = FileEncryptor.EncryptData(passKey, salt, iV, jsonAccount);
                if (encrypted == null) return false;
                jsonAccount = encrypted;
            }

            string maDir = GetManifestDir();
            string filename = account.Session.SteamID.ToString() + ".maFile";

            ManifestEntry newEntry = new ManifestEntry()
            {
                SteamID = account.Session.SteamID,
                IV = iV,
                Salt = salt,
                Filename = filename
            };

            bool foundExistingEntry = false;
            for (int i = 0; i < this.Entries.Count; i++)
            {
                if (this.Entries[i].SteamID == account.Session.SteamID)
                {
                    this.Entries[i] = newEntry;
                    foundExistingEntry = true;
                    break;
                }
            }

            if (!foundExistingEntry)
            {
                this.Entries.Add(newEntry);
            }

            bool wasEncrypted = this.Encrypted;
            this.Encrypted = encrypt || this.Encrypted;

            if (!this.Save())
            {
                this.Encrypted = wasEncrypted;
                return false;
            }

            try
            {
                File.WriteAllText(Path.Combine(maDir, filename), jsonAccount);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save()
        {
            string maDir = GetManifestDir();
            string filename = Path.Combine(maDir, ConstantsController.MA_MANIFEST_FILE_NAME);
            if (!Directory.Exists(maDir))
            {
                try
                {
                    Directory.CreateDirectory(maDir);
                }
                catch (Exception)
                {
                    return false;
                }
            }

            try
            {
                string contents = JsonConvert.SerializeObject(this);
                File.WriteAllText(filename, contents);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// This class provides the controls that will encrypt and decrypt the *.maFile files
    /// 
    /// Passwords entered will be passed into 100k rounds of PBKDF2 (RFC2898) with a cryptographically random salt.
    /// The generated key will then be passed into AES-256 (RijndalManaged) which will encrypt the data
    /// in cypher block chaining (CBC) mode, and then write both the PBKDF2 salt and encrypted data onto the disk.
    /// </summary>
    internal static class FileEncryptor
    {
        private const int PBKDF2_ITERATIONS = 50000; //Set to 50k to make program not unbearably slow. May increase in future.
        private const int SALT_LENGTH = 8;
        private const int KEY_SIZE_BYTES = 32;
        private const int IV_LENGTH = 16;

        /// <summary>
        /// Returns an 8-byte cryptographically random salt in base64 encoding
        /// </summary>
        /// <returns></returns>
        public static string GetRandomSalt()
        {
            byte[] salt = new byte[SALT_LENGTH];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }

        /// <summary>
        /// Returns a 16-byte cryptographically random initialization vector (IV) in base64 encoding
        /// </summary>
        /// <returns></returns>
        public static string GetInitializationVector()
        {
            byte[] IV = new byte[IV_LENGTH];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(IV);
            }
            return Convert.ToBase64String(IV);
        }


        /// <summary>
        /// Generates an encryption key derived using a password, a random salt, and specified number of rounds of PBKDF2
        /// 
        /// TODO: pass in password via SecureString?
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        private static byte[] GetEncryptionKey(string password, string salt)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is empty");
            }
            if (string.IsNullOrEmpty(salt))
            {
                throw new ArgumentException("Salt is empty");
            }
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), PBKDF2_ITERATIONS))
            {
                return pbkdf2.GetBytes(KEY_SIZE_BYTES);
            }
        }

        /// <summary>
        /// Tries to decrypt and return data given an encrypted base64 encoded string. Must use the same
        /// password, salt, IV, and ciphertext that was used during the original encryption of the data.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="IV">Initialization Vector</param>
        /// <param name="encryptedData"></param>
        /// <returns></returns>
        public static string DecryptData(string password, string passwordSalt, string IV, string encryptedData)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is empty");
            }
            if (string.IsNullOrEmpty(passwordSalt))
            {
                throw new ArgumentException("Salt is empty");
            }
            if (string.IsNullOrEmpty(IV))
            {
                throw new ArgumentException("Initialization Vector is empty");
            }
            if (string.IsNullOrEmpty(encryptedData))
            {
                throw new ArgumentException("Encrypted data is empty");
            }

            byte[] cipherText = Convert.FromBase64String(encryptedData);
            byte[] key = GetEncryptionKey(password, passwordSalt);
            string plaintext = null;

            using (RijndaelManaged aes256 = new RijndaelManaged())
            {
                aes256.IV = Convert.FromBase64String(IV);
                aes256.Key = key;
                aes256.Padding = PaddingMode.PKCS7;
                aes256.Mode = CipherMode.CBC;

                //create decryptor to perform the stream transform
                ICryptoTransform decryptor = aes256.CreateDecryptor(aes256.Key, aes256.IV);

                //wrap in a try since a bad password yields a bad key, which would throw an exception on decrypt
                try
                {
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                    {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
                catch (CryptographicException)
                {
                    plaintext = null;
                }
            }
            return plaintext;
        }

        /// <summary>
        /// Encrypts a string given a password, salt, and initialization vector, then returns result in base64 encoded string.
        /// 
        /// To retrieve this data, you must decrypt with the same password, salt, IV, and cyphertext that was used during encryption
        /// </summary>
        /// <param name="password"></param>
        /// <param name="passwordSalt"></param>
        /// <param name="IV"></param>
        /// <param name="plaintext"></param>
        /// <returns></returns>
        public static string EncryptData(string password, string passwordSalt, string IV, string plaintext)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password is empty");
            }
            if (string.IsNullOrEmpty(passwordSalt))
            {
                throw new ArgumentException("Salt is empty");
            }
            if (string.IsNullOrEmpty(IV))
            {
                throw new ArgumentException("Initialization Vector is empty");
            }
            if (string.IsNullOrEmpty(plaintext))
            {
                throw new ArgumentException("Plaintext data is empty");
            }
            byte[] key = GetEncryptionKey(password, passwordSalt);
            byte[] ciphertext;

            using (RijndaelManaged aes256 = new RijndaelManaged())
            {
                aes256.Key = key;
                aes256.IV = Convert.FromBase64String(IV);
                aes256.Padding = PaddingMode.PKCS7;
                aes256.Mode = CipherMode.CBC;

                ICryptoTransform encryptor = aes256.CreateEncryptor(aes256.Key, aes256.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncypt = new StreamWriter(csEncrypt))
                        {
                            swEncypt.Write(plaintext);
                        }
                        ciphertext = msEncrypt.ToArray();
                    }
                }
            }
            return Convert.ToBase64String(ciphertext);
        }
    }

}
