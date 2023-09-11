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
    public partial class AccountInfoPanelUserControl : UserControl
    {
        private string _marketApiKey;

        public AccountInfoPanelUserControl(Image avatar, string accountNickname, string accountLogin, string accountSteamID64, string accountType,
                                          string marketApiKey = null)
        {
            InitializeComponent();

            _marketApiKey = marketApiKey;

            pictureBoxSteamAccountAvatar.Image = avatar;
            textBoxSteamAccountName.Text = accountNickname;
            textBoxSteamAccountLogin.Text = accountLogin;
            textBoxAccountTypeInProgram.Text = accountType;
            textBoxAccountSteamID64.Text = accountSteamID64;

            if (_marketApiKey == null)
            {
                labelMarketAPIKey.Enabled = false;
                textBoxMarketAPIKey.Enabled = false;
                labelMarketAPIKeyStatus.Enabled = false;

                labelMarketAPIKeyStatus.ForeColor = Color.DarkGray;
                labelMarketAPIKeyStatus.Text = "Not a Market acc";
            }
            else
            {
                textBoxMarketAPIKey.Text = MarketAPIController.GetCensoredAPIKeyString(_marketApiKey);

                RefreshMarketStatus();
            }
        }

        public void RefreshMarketStatus()
        {
            MarketAPIController api = new MarketAPIController(Models.SteamGame.CS, _marketApiKey);
            if (api.IsMarketOnline())
            {
                bool isKeyValid = api.CheckAPIKey();
                if (isKeyValid)
                {
                    labelMarketAPIKeyStatus.ForeColor = Color.Green;
                    labelMarketAPIKeyStatus.Text = "API key is OK.";
                }
                else
                {
                    labelMarketAPIKeyStatus.ForeColor = Color.DarkRed;
                    labelMarketAPIKeyStatus.Text = "API key is BAD.";
                }
            }
            else
            {
                labelMarketAPIKeyStatus.ForeColor = Color.OrangeRed;
                labelMarketAPIKeyStatus.Text = "Market is DOWN.";
            }
        }
    }
}
