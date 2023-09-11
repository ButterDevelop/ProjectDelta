using ProjectDelta.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class AutoMarketUserControl : UserControl
    {
        internal List<AccountInfoPanelUserControl> panels = new List<AccountInfoPanelUserControl>();

        public AutoMarketUserControl()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Properties.Settings.Default.MAFilesPath) ||
                DBController.PlayingAccounts.Count + DBController.BufferAccounts.Count + DBController.MarketAccounts.Count == 0
               )
            {
                this.Visible = false;
            }

            int counter = 0;
            foreach (var account in DBController.MarketAccounts)
            {
                string steamId = account.Key;

                var profile = DBController.SteamWebProfiles.FirstOrDefault(a => a.SteamId == steamId);
                if (profile == null) continue;

                string accountNickname = profile.Nickname;
                Image avatar = profile.FullAvatarImage;

                string accountLogin = account.Value.AccountName;
                string accountType = "Market account";
                string marketApiKey = DBController.MarketAccountsAPIKeys[steamId];

                panels.Add(new AccountInfoPanelUserControl(avatar, accountNickname, accountLogin, steamId, accountType, marketApiKey));

                ++counter;
            }

            foreach (var panel in panels) flowLayoutPanelAutoMarket.Controls.Add(panel);
        }
    }
}
