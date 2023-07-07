using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelta.Models
{
    internal class InventoryItem
    {
        private string _marketHashName;
        private int _appId;
        private long _ownerSteamId;
        private bool _marketable;
        private bool _tradable;
        private DateTime _dateBanEnd;

        public InventoryItem()
        {
            _marketHashName = "";
            _appId = 0;
            _ownerSteamId = 0;
            _marketable = false;
            _tradable = false;
            _dateBanEnd = DateTime.MinValue;
        }

        public InventoryItem(string marketHashName, int appId, long ownerSteamId, bool marketable, bool tradable, DateTime dateBanEnd)
        {
            _marketHashName = marketHashName;
            _appId = appId;
            _ownerSteamId = ownerSteamId;
            _marketable = marketable;
            _tradable = tradable;
            _dateBanEnd = dateBanEnd;
        }

        public string MarketHashName
        {
            get { return _marketHashName; }
            set { _marketHashName = value; }
        }

        public int AppId
        {
            get { return _appId; }
            set { _appId = value; }
        }

        public long OwnerSteamId
        {
            get { return _ownerSteamId; }
            set { _ownerSteamId = value; }
        }

        public bool Marketable
        {
            get { return _marketable; }
            set { _marketable = value; }
        }

        public bool Tradable
        {
            get { return _tradable; }
            set { _tradable = value; }
        }

        public bool IsBanned
        {
            get 
            { 
                return DateTime.Now > _dateBanEnd; 
            }
        }

        public DateTime DateBanEnd
        { 
            get { return _dateBanEnd; }
            set { _dateBanEnd = value; } 
        }


    }
}
