using ProjectDelta.Tools;

namespace ProjectDelta.Controllers
{
    internal class ConstantsController
    {
        internal static readonly string MA_MANIFEST_FILE_NAME  = "manifest.json";
        internal static readonly string MA_FILES_PASSKEY       = B64X.Encrypt("MAFilesPassword");
        internal static readonly string ENCRYPTION_KEY_PATH    = B64X.Encrypt("TranslationProperties.dll");
        internal static readonly string DB_FILE_PATH           = "deltaDB.json";
        internal static readonly int SAVE_REFRESH_RATE_MS = 1000;
        internal const string URL_FOR_GETTING_LAST_DB_FROM_SERVER = "http://a116901.hostde27.fornex.host/delta/license/retrieveSyncDB.php";
        internal const string URL_FOR_SENDING_DB_TO_SERVER        = "http://a116901.hostde27.fornex.host/delta/license/insertSyncDB.php";

        internal static readonly string ACCOUNT_TYPE_STRING_MARKET  = "market";
        internal static readonly string ACCOUNT_TYPE_STRING_PLAYING = "playing";
        internal static readonly string ACCOUNT_TYPE_STRING_BUFFER  = "buffer";
    }
}
