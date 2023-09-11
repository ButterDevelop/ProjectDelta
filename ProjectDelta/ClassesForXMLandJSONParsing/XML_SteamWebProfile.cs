using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProjectDelta.ClassesForXMLandJSONParsing
{
    public class XML_SteamWebProfile
    {
        [XmlRoot(ElementName = "group")]
        public class Group
        {
            [XmlElement(ElementName = "groupID64")]
            public double GroupID64 { get; set; }

            [XmlElement(ElementName = "groupName")]
            public string GroupName { get; set; }

            [XmlElement(ElementName = "groupURL")]
            public string GroupURL { get; set; }

            [XmlElement(ElementName = "headline")]
            public object Headline { get; set; }

            [XmlElement(ElementName = "summary")]
            public string Summary { get; set; }

            [XmlElement(ElementName = "avatarIcon")]
            public string AvatarIcon { get; set; }

            [XmlElement(ElementName = "avatarMedium")]
            public string AvatarMedium { get; set; }

            [XmlElement(ElementName = "avatarFull")]
            public string AvatarFull { get; set; }

            [XmlElement(ElementName = "memberCount")]
            public int MemberCount { get; set; }

            [XmlElement(ElementName = "membersInChat")]
            public int MembersInChat { get; set; }

            [XmlElement(ElementName = "membersInGame")]
            public int MembersInGame { get; set; }

            [XmlElement(ElementName = "membersOnline")]
            public int MembersOnline { get; set; }

            [XmlAttribute(AttributeName = "isPrimary")]
            public int IsPrimary { get; set; }

            [XmlText]
            public string Text { get; set; }
        }

        [XmlRoot(ElementName = "groups")]
        public class Groups
        {
            [XmlElement(ElementName = "group")]
            public List<Group> Group { get; set; }
        }

        [XmlRoot("profile")]
        public class Profile
        {
            [XmlElement("steamID64")]
            public string SteamID64 { get; set; }

            [XmlElement("steamID")]
            public string SteamID { get; set; }

            [XmlElement("onlineState")]
            public string OnlineState { get; set; }

            [XmlElement("stateMessage")]
            public string StateMessage { get; set; }

            [XmlElement("privacyState")]
            public string PrivacyState { get; set; }

            [XmlElement("visibilityState")]
            public int VisibilityState { get; set; }

            [XmlElement("avatarIcon")]
            public string AvatarIcon { get; set; }

            [XmlElement("avatarMedium")]
            public string AvatarMedium { get; set; }

            [XmlElement("avatarFull")]
            public string AvatarFull { get; set; }

            [XmlElement("vacBanned")]
            public int VacBanned { get; set; }

            [XmlElement("tradeBanState")]
            public string TradeBanState { get; set; }

            [XmlElement("isLimitedAccount")]
            public int IsLimitedAccount { get; set; }

            [XmlElement("customURL")]
            public string CustomURL { get; set; }

            [XmlElement("memberSince")]
            [XmlText]
            public string MemberSince { get; set; }

            [XmlElement("steamRating")]
            public string SteamRating { get; set; }

            [XmlElement("hoursPlayed2Wk")]
            public double HoursPlayed2Wk { get; set; }

            [XmlElement("headline")]
            public string Headline { get; set; }

            [XmlElement("location")]
            public string Location { get; set; }

            [XmlElement("realname")]
            public string RealName { get; set; }

            [XmlElement("summary")]
            public string Summary { get; set; }

            // Добавляем атрибут [XmlText] для обработки даты
            /*[XmlElement("memberSince")]
            [XmlText]
            public string MemberSinceText { get; set; }

            // Парсим дату из строки
            [XmlIgnore]
            public DateTime MemberSinceDate
            {
                get { return DateTime.Parse(MemberSinceText); }
            }*/

            [XmlElement(ElementName = "groups")]
            public Groups Groups { get; set; }
        }

    }
}
