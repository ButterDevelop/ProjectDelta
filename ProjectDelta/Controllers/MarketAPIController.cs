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

        private static readonly string ADD_TO_SALE_ENDPOINT = "add-to-sale";
        private static readonly string TEST_ENDPOINT        = "test";

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

        public bool AddToSale(string item_id, double price_double, string currency = MARKET_CURRENCY_USD)
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

            if (json_answer == null || !json_answer.Contains("\"success\": true")) return false;
            return true;
        }

        public bool Test()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + TEST_ENDPOINT, RequestType.GET, null, parameters);

            if (json_answer == null || !json_answer.Contains("\"success\": true")) return false;
            return true;
        }

        public bool CheckAPIKey()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + TEST_ENDPOINT, RequestType.GET, null, parameters, 100);

            if (json_answer == null || json_answer.ToLower().Contains("bad key")) return false;
            return true;
        }

        public bool IsMarketOnline()
        {
            string url = GetBaseURLFromSteamGame();

            Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "key", _apiKey }
            };

            string json_answer = HTTPRequestController.SendRequest(url + TEST_ENDPOINT, RequestType.GET, null, parameters, 100);

            if (json_answer == null || json_answer.ToLower().Contains("<html>")) return false;
            return true;
        }
    }
}
