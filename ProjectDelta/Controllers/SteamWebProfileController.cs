using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using ProjectDelta.ClassesForXMLandJSONParsing;
using System.Windows.Forms;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Drawing.Imaging;

namespace ProjectDelta.Controllers
{
    internal class SteamWebProfileController
    {
        private static readonly string MASK_STEAM_PROFILE_XML_URL = "%SteamID%";
        private static readonly string STEAM_PROFILE_XML_URL = $"https://steamcommunity.com/profiles/{MASK_STEAM_PROFILE_XML_URL}/?xml=1";

        private XML_SteamWebProfile.Profile _xmlData;

        private bool _lastParse;
        private string _steamId;

        private string _nickname;

        private string _fullAvatarUrl;
        private Image _fullAvatarImage;
        private string _fullAvatarImageBase64;


        public SteamWebProfileController()
        {
            _lastParse = false;
            _steamId = "";
            _nickname = "";
            _fullAvatarUrl = "";
            _fullAvatarImage = null;
            _fullAvatarImageBase64 = "";
            _xmlData = null;
        }

        public SteamWebProfileController(string steamId) : this()
        {
            _steamId = steamId;

            RefreshData();
        }

        public bool LastParse
        {
            get
            {
                return _lastParse;
            }
            set
            {
                _lastParse = value;
            }
        }

        public string SteamId
        {
            get
            {
                return _steamId;
            }
            set
            {
                _steamId = value;
            }
        }

        public string Nickname
        {
            get
            {
                return _nickname;
            }
            set
            {
                _nickname = value;
            }
        }

        public string FullAvatarUrl
        {
            get
            {
                return _fullAvatarUrl;
            }
            set
            {
                _fullAvatarUrl = value;
            }
        }

        public string FullAvatarImageBase64
        {
            get
            {
                return _fullAvatarImageBase64;
            }
            set
            {
                _fullAvatarImageBase64 = value;
                _fullAvatarImage = ConvertBase64ToImage(_fullAvatarImageBase64);
            }
        }

        [JsonIgnore]
        public Image FullAvatarImage
        {
            get
            {
                return _fullAvatarImage;
            }
        }

        [JsonIgnore]
        public XML_SteamWebProfile.Profile XmlData
        {
            get
            {
                return _xmlData;
            }
        }


        public static Image ConvertBase64ToImage(string str)
        {
            if (!string.IsNullOrEmpty(str))
            {
                // Преобразуем строку Base64 в массив байтов
                byte[] imageBytes = Convert.FromBase64String(str);

                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    // Создаем изображение из потока
                    return Image.FromStream(ms);
                }
            }
            return null;
        }

        public void RefreshData()
        {
            try
            {
                string url = STEAM_PROFILE_XML_URL.Replace(MASK_STEAM_PROFILE_XML_URL, _steamId);
                string xml = HTTPRequestController.SendRequest(url, RequestType.GET, null, null);

                // Using XmlSerializer to deserialize XML in an object
                using (TextReader reader = new StringReader(xml))
                {
                    using (XmlReader xmlReader = XmlReader.Create(reader))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(XML_SteamWebProfile.Profile));
                        _xmlData = (XML_SteamWebProfile.Profile)serializer.Deserialize(xmlReader);
                    }
                }

                _nickname = _xmlData.SteamID;

                if (_xmlData != null && !string.IsNullOrEmpty(_xmlData.AvatarFull)
                   && (_fullAvatarUrl != _xmlData.AvatarFull || string.IsNullOrEmpty(_fullAvatarImageBase64)))
                {
                    _fullAvatarUrl = _xmlData.AvatarFull;
                    //Doing this assignment with a setter usage
                    FullAvatarImageBase64 = HTTPRequestController.DownloadImageBase64FromURL(_fullAvatarUrl);
                }

                _lastParse = true;
            }
            catch
            {
                _lastParse = false;
            }
        }

    }
}
