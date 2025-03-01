﻿using ProjectDelta.Controllers;
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
        //public Dictionary<string, SteamGuardAccount> PlayingAccounts { get; set; }
        //public Dictionary<string, SteamGuardAccount> BufferAccounts { get; set; }
        //public Dictionary<string, SteamGuardAccount> MarketAccounts { get; set; }
        public List<string> PlayingAccountsSteamIDs { get; set; }
        public List<string> MarketAccountsSteamIDs { get; set; }
        public Dictionary<string, string>  MarketAccountsAPIKeys { get; set; }
        public List<SteamWebProfileController> SteamWebProfiles { get; set; }
    }
}
