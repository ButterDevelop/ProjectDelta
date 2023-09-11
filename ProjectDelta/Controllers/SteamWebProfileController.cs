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


        public SteamWebProfileController()
        {
            _lastParse = false;
            _steamId = "";
            _nickname = "";
            _fullAvatarUrl = "";
            _fullAvatarImage = null;
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
        }

        public string SteamId
        {
            get
            {
                return _steamId;
            }
        }

        public string Nickname
        {
            get
            {
                return _nickname;
            }
        }

        public string FullAvatarUrl
        {
            get
            {
                return _fullAvatarUrl;
            }
        }

        public Image FullAvatarImage
        {
            get
            {
                return _fullAvatarImage;
            }
        }

        public XML_SteamWebProfile.Profile XmlData
        {
            get
            {
                return _xmlData;
            }
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

                if (!string.IsNullOrEmpty(_xmlData.AvatarFull) && _fullAvatarUrl != _xmlData.AvatarFull)
                {
                    _fullAvatarUrl = _xmlData.AvatarFull;
                    Image image = HTTPRequestController.DownloadImageFromURL(_fullAvatarUrl);
                    _fullAvatarImage = image;
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
