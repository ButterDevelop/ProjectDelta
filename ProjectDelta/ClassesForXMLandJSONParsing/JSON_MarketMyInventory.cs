using System.Collections.Generic;

namespace ProjectDelta.ClassesForXMLandJSONParsing
{
    internal class JSON_MarketMyInventory
    {
        public class Root
        {
            public bool success { get; set; }
            public List<Models.MarketItem> items { get; set; }
        }
    }
}
