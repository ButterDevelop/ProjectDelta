using Newtonsoft.Json;
using ProjectDelta.ClassesForJSONandXMLParsing;
using ProjectDelta.Controllers;
using System;
using System.Collections.Generic;

namespace ProjectDelta.Models
{
    internal enum SteamGame
    {
        CS = 730,
        DOTA = 570
    }

    internal class InventoryModel
    {
        public readonly static int[] AppIDs = new int[2] { 730, 570 };
        public readonly static string MASK_OWNER_STEAM_ID = "%OwnerSteamID64%", MASK_APP_ID = "%AppId%", MASK_ON_TRADE_COOLDOWN_UNTIL = "On Trade Cooldown Until: ";
        public readonly static string BASE_STEAM_INVENTORY_URL = $"https://steamcommunity.com/inventory/{MASK_OWNER_STEAM_ID}/{MASK_APP_ID}/2";

        private long _ownerSteamID;
        private string _url;
        private List<InventoryItem> _inventoryItems;

        public InventoryModel() 
        {
            _url = "";
            _ownerSteamID = 0;
            _inventoryItems = new List<InventoryItem>();
        }

        public InventoryModel(long ownerSteamID)
        {
            _ownerSteamID = ownerSteamID;
            _url = BASE_STEAM_INVENTORY_URL.Replace(MASK_OWNER_STEAM_ID, ownerSteamID.ToString());
            _inventoryItems = new List<InventoryItem>();
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public List<InventoryItem> InventoryItems
        {
            get { return _inventoryItems; }
            set { _inventoryItems = value; }
        }

        public long OwnerSteamID
        {
            get { return _ownerSteamID; }
            set { _ownerSteamID = value; }
        }

        public string SendGetInventoryRequest(int appId, long start_assetid = -1)
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "l", "english" },
                { "count", "2000" }
            };
            if (start_assetid != -1)
            {
                parameters.Add("start_assetid", start_assetid.ToString());
            }
            string jsonString = HTTPRequestController.SendRequest(_url.Replace(MASK_APP_ID, appId.ToString()), RequestType.GET, null, parameters);
            return jsonString;
        }

        public void GetInventoryRequest()
        {
            foreach (var appId in AppIDs)
            {
                bool hasNextPage = true;
                long start_assetid = -1;

                while (hasNextPage)
                {
                    hasNextPage = false;

                    string jsonString = HTTPRequestController.ExecuteFunctionUntilSuccess(() => SendGetInventoryRequest(appId, start_assetid));
                    if (jsonString is null) break;

                    JSON_Inventory.Root inventory = JsonConvert.DeserializeObject<JSON_Inventory.Root>(jsonString);
                    foreach (var description in inventory.descriptions)
                    {
                        DateTime onTradeCooldownUntil = DateTime.MinValue;
                        foreach (var text_description in description.descriptions)
                        {
                            if (text_description.value != null && text_description.value.Contains(MASK_ON_TRADE_COOLDOWN_UNTIL))
                                onTradeCooldownUntil = DateTime.Parse(text_description.value.Replace(MASK_ON_TRADE_COOLDOWN_UNTIL, ""));
                        }

                        long classId = long.Parse(description.classid);
                        long instanceId = long.Parse(description.instanceid);

                        var inventoryItem = new InventoryItem(description.market_hash_name, appId, classId, instanceId, _ownerSteamID,
                                                              description.marketable == 1, description.tradable == 1, onTradeCooldownUntil);
                        InventoryItems.Add(inventoryItem);
                    }

                    if (inventory.last_assetid != null)
                    {
                        hasNextPage = true;
                        start_assetid = long.Parse(inventory.last_assetid);
                    }
                }
            }

        }


    }
}
