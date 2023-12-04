using Newtonsoft.Json;
using ProjectDelta.ClassesForJSONandXMLParsing;
using ProjectDelta.ClassesForXMLandJSONParsing;
using ProjectDelta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDelta.Controllers
{
    internal enum MarketAPIAnswer
    {
        ServerDown = 0,
        BadKey = 1,
        Error = 2,
        UpdateInventory = 3,
        TryLater = 4,
        OK = 5
    }

    internal class MarketAPIController
    {
        public const string MARKET_CURRENCY_RUB = "RUB";
        public const string MARKET_CURRENCY_USD = "USD";
        public const string MARKET_CURRENCY_EUR = "EUR";
        private const int MARKET_CURRENCY_PRICE_MULTIPLIER_USD = 1000;
        private const int MARKET_CURRENCY_PRICE_MULTIPLIER_EUR = 1000;
        private const int MARKET_CURRENCY_PRICE_MULTIPLIER_RUB = 100;

        private static readonly string MARKET_CS_BASE_URL   = "https://market.csgo.com/api/v2/";
        private static readonly string MARKET_DOTA_BASE_URL = "https://market.dota2.net/api/v2/";

        private static readonly string ADD_TO_SALE_ENDPOINT     = "add-to-sale";
        private static readonly string TEST_ENDPOINT            = "test";
        private static readonly string GET_MY_STEAM_ID_ENDPOINT = "get-my-steam-id";
        private static readonly string MY_INVENTORY_ENDPOINT    = "my-inventory";
        private static readonly string PING_ENDPOINT            = "ping";
        private static readonly string GO_OFFLINE_ENDPOINT      = "go-offline";

        private SteamGame _game;
        private string    _apiKey;

        public MarketAPIController(SteamGame game, string apiKey) 
        {
            _game = game;
            _apiKey = apiKey;
        }

        public SteamGame Game
        {
            get
            {
                return _game;
            }
        }


        public static string GetCensoredAPIKeyString(string key)
        {
            return key.Substring(0, 10) + "...";
        }


        public string GetBaseURLFromSteamGame()
        {
            string url = "";
            switch (_game)
            {
                case SteamGame.CS: url = MARKET_CS_BASE_URL; break;
                case SteamGame.DOTA: url = MARKET_DOTA_BASE_URL; break;
            }

            return url;
        }

        public MarketAPIAnswer AddToSale(string item_id, double price_double, string currency = MARKET_CURRENCY_USD)
        {
            int price = 0;
            switch (currency)
            {
                case MARKET_CURRENCY_USD: price = (int)(price_double * MARKET_CURRENCY_PRICE_MULTIPLIER_USD); break;
                case MARKET_CURRENCY_EUR: price = (int)(price_double * MARKET_CURRENCY_PRICE_MULTIPLIER_EUR); break;
                case MARKET_CURRENCY_RUB: price = (int)(price_double * MARKET_CURRENCY_PRICE_MULTIPLIER_RUB); break;
            }

            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key",   _apiKey },
                { "id",    item_id },
                { "price", price.ToString() },
                { "cur",   currency }
            };

            string json_answer = HTTPRequestController.SendRequest(url + ADD_TO_SALE_ENDPOINT, RequestType.GET, null, parameters);

            return GetMarketAPIAnswerFromString(json_answer);
        }

        public MarketAPIAnswer Test()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + TEST_ENDPOINT, RequestType.GET, null, parameters);

            return GetMarketAPIAnswerFromString(json_answer);
        }

        public List<MarketItem> MyInventory()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + MY_INVENTORY_ENDPOINT, RequestType.GET, null, parameters, null, 10 * 1000);

            JSON_MarketMyInventory.Root json_parsed = JsonConvert.DeserializeObject<JSON_MarketMyInventory.Root>(json_answer);
            List<MarketItem> answerList = new List<MarketItem>(json_parsed.items);

            return answerList;
        }

        public MarketAPIAnswer GetMySteamId()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + GET_MY_STEAM_ID_ENDPOINT, RequestType.GET, null, parameters);

            return GetMarketAPIAnswerFromString(json_answer);
        }

        public MarketAPIAnswer Ping()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + PING_ENDPOINT, RequestType.GET, null, parameters);

            return GetMarketAPIAnswerFromString(json_answer);
        }

        public MarketAPIAnswer GoOffline()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + GO_OFFLINE_ENDPOINT, RequestType.GET, null, parameters);

            return GetMarketAPIAnswerFromString(json_answer);
        }


        public bool CheckAPIKey()
        {
            return GetMySteamId() == MarketAPIAnswer.OK;
        }

        public bool IsMarketOnline()
        {
            return GetMySteamId() == MarketAPIAnswer.ServerDown;
        }


        public static MarketAPIAnswer GetMarketAPIAnswerFromString(string answer)
        {
            if (answer == null) return MarketAPIAnswer.Error;
            answer = answer.ToLower();
            if (answer.Contains("<html>")) return MarketAPIAnswer.ServerDown;
            if (answer.Contains("bad key")) return MarketAPIAnswer.BadKey;
            if (answer.Contains("\"success\":true")) return MarketAPIAnswer.OK;

            if (answer.Contains("inventory_not_loaded") || answer.Contains("item_not_recieved") || 
                answer.Contains("item_not_in_inventory")) return MarketAPIAnswer.UpdateInventory;

            if (answer.Contains("no_description_found")) return MarketAPIAnswer.TryLater;

            return MarketAPIAnswer.Error;
        }
    }
}
