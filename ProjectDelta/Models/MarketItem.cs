namespace ProjectDelta.Models
{
    internal class MarketItem
    {
        private string _id;
        private string _classid;
        private string _instanceid;
        private string _market_hash_name;
        private double _market_price;
        private int _tradable;

        public MarketItem() 
        {
            _id = "";
            _classid = "";
            _instanceid = "";
            _market_hash_name = "";
            _market_price = 0.0;
            _tradable = 0;
        }

        public MarketItem(string id, string classid, string instanceid, string market_hash_name, double market_price, int tradable)
        {
            _id = id;
            _classid = classid;
            _instanceid = instanceid;
            _market_hash_name = market_hash_name;
            _market_price = market_price;
            _tradable = tradable;
        }

        public string Id 
        { 
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string ClassId 
        { 
            get
            {
                return _classid;
            }
            set
            {
                _classid = value;
            }
        }

        public string InstanceId 
        { 
            get
            {
                return _instanceid;
            }
            set
            {
                _instanceid = value;
            }
        }

        public string MarketHashName 
        { 
            get
            {
                return _market_hash_name;
            }
            set
            {
                _market_hash_name = value;
            }
        }

        public double MarketPrice 
        { 
            get
            {
                return _market_price;
            }
            set
            {
                _market_price = value;
            }
        }

        public int Tradable 
        { 
            get
            {
                return _tradable;
            }
            set
            {
                _tradable = value;
            }
        }

    }
}
