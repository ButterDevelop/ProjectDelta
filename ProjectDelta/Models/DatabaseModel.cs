using SteamAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectDelta.Models
{
    internal class DatabaseModel
    {
        public Dictionary<string, SteamGuardAccount> PlayingAccounts { get; set; }
        public Dictionary<string, SteamGuardAccount> BufferAccounts { get; set; }
        public Dictionary<string, SteamGuardAccount> MarketAccounts { get; set; }
    }
}
