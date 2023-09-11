using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelta.ClassesForJSONandXMLParsing
{
    public class JSON_Inventory
    {
        public class Action
        {
            public string link { get; set; }
            public string name { get; set; }
        }

        public class Asset
        {
            public int appid { get; set; }
            public string contextid { get; set; }
            public string assetid { get; set; }
            public string classid { get; set; }
            public string instanceid { get; set; }
            public string amount { get; set; }
        }

        public class TextDescription
        {
            public string type { get; set; }
            public string value { get; set; }
            public string color { get; set; }
        }

        public class Description
        {
            public int appid { get; set; }
            public string classid { get; set; }
            public string instanceid { get; set; }
            public int currency { get; set; }
            public string background_color { get; set; }
            public string icon_url { get; set; }
            public string icon_url_large { get; set; }
            public List<TextDescription> descriptions { get; set; }
            public int tradable { get; set; }
            public List<Action> actions { get; set; }
            public string name { get; set; }
            public string name_color { get; set; }
            public string type { get; set; }
            public string market_name { get; set; }
            public string market_hash_name { get; set; }
            public List<MarketAction> market_actions { get; set; }
            public int commodity { get; set; }
            public int market_tradable_restriction { get; set; }
            public int marketable { get; set; }
            public List<Tag> tags { get; set; }
            public string market_buy_country_restriction { get; set; }
            public string value { get; set; }
            public string color { get; set; }
        }

        public class MarketAction
        {
            public string link { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public List<Asset> assets { get; set; }
            public List<Description> descriptions { get; set; }
            public int more_items { get; set; }
            public string last_assetid { get; set; }
            public int total_inventory_count { get; set; }
            public int success { get; set; }
            public int rwgrsn { get; set; }
        }

        public class Tag
        {
            public string category { get; set; }
            public string internal_name { get; set; }
            public string localized_category_name { get; set; }
            public string localized_tag_name { get; set; }
            public string color { get; set; }
        }
    }
}
