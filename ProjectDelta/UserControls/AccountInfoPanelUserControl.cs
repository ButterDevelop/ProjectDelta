using ProjectDelta.Controllers;
using SteamAuth;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class AccountInfoPanelUserControl : UserControl
    {
        public static readonly int REFRESH_ALL_MARKET_PANELS_TIMEOUT_MS = 2 * 60 * 1000;

        private Image _avatar;
        private string _accountNickname;
        private string _accountLogin;
        private string _accountSteamID64;
        private string _accountType;
        private string _marketApiKey;

        public AccountInfoPanelUserControl(Image avatar, string accountNickname, string accountLogin, string accountSteamID64, string accountType,
                                          string marketApiKey = null)
        {
            InitializeComponent();

            _avatar = avatar;
            _accountNickname = accountNickname;
            _accountLogin = accountLogin;
            _accountSteamID64 = accountSteamID64;
            _accountType = accountType;
            _marketApiKey = marketApiKey;

            pictureBoxSteamAccountAvatar.Image = _avatar;
            textBoxSteamAccountName.Text = _accountNickname;
            textBoxSteamAccountLogin.Text = _accountLogin;
            textBoxAccountTypeInProgram.Text = _accountType;
            textBoxAccountSteamID64.Text = _accountSteamID64;

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
            }
        }

        public void RefreshMarketStatus()
        {
            UpdateLabel(labelMarketAPIKeyStatus, "Refreshing...", Color.DimGray);

            MarketAPIController api = new MarketAPIController(Models.SteamGame.CS, _marketApiKey);
            if (api.IsMarketOnline())
            {
                bool isKeyValid = api.CheckAPIKey();
                if (isKeyValid)
                {
                    UpdateLabel(labelMarketAPIKeyStatus, "API key is OK.", Color.Green);
                }
                else
                {
                    UpdateLabel(labelMarketAPIKeyStatus, "API key is BAD.", Color.DarkRed);
                }
            }
            else
            {
                UpdateLabel(labelMarketAPIKeyStatus, "Server is DOWN.", Color.OrangeRed);
            }
        }

        private void UpdateLabel(Label label, string text, Color color)
        {
            if (label.InvokeRequired)
            {
                // Если это не основной поток, вызываем метод снова через Invoke
                this.Invoke(new Action<Label, string, Color>(UpdateLabel), label, text, color);
            }
            else
            {
                // Это основной поток, можно обновить Label
                label.Text = text;
                label.ForeColor = color;
            }
        }

        public Image Avatar
        {
            get
            {
                return _avatar;
            }
        }

        public string AccountNickname
        {
            get
            {
                return _accountNickname;
            }
        }

        public string AccountLogin
        {
            get
            {
                return _accountLogin;
            }
        }

        public string AccountSteamID64
        {
            get
            {
                return _accountSteamID64;
            }
        }

        public string AccountType
        {
            get
            {
                return _accountType;
            }
        }

        public string MarketAPIKey
        {
            get
            {
                return _marketApiKey;
            }
        }


        public static List<AccountInfoPanelUserControl> GetUIAccountsPanels(Dictionary<string, SteamGuardAccount> accounts)
        {
            try
            {
                List<AccountInfoPanelUserControl> panels = new List<AccountInfoPanelUserControl>();

                foreach (var account in accounts)
                {
                    var panel = GetAccountInfoUIPanel(account);
                    if (panel == null) continue;
                    panels.Add(panel);
                }

                return panels;
            }
            catch
            {
                return null;
            }
        }
        private static AccountInfoPanelUserControl GetAccountInfoUIPanel(KeyValuePair<string, SteamGuardAccount> account)
        {
            string steamId = account.Key;

            var profile = DBController.SteamWebProfiles.FirstOrDefault(a => a.SteamId == steamId);
            if (profile == null) return null;

            string accountNickname = profile.Nickname;
            Image avatar = profile.FullAvatarImage;

            string accountLogin = account.Value.AccountName;
            string accountType = DBController.MarketAccountsSteamIDs.Contains(steamId) ? ConstantsController.ACCOUNT_TYPE_STRING_MARKET :
                                   (DBController.PlayingAccountsSteamIDs.Contains(steamId) ? ConstantsController.ACCOUNT_TYPE_STRING_PLAYING : ConstantsController.ACCOUNT_TYPE_STRING_BUFFER);
            string marketApiKey = DBController.MarketAccountsAPIKeys.ContainsKey(steamId) ? DBController.MarketAccountsAPIKeys[steamId] : null;

            return new AccountInfoPanelUserControl(avatar, accountNickname, accountLogin, steamId, accountType, marketApiKey);
        }

        public static void RefreshAllMarketStatusesInControl(Control elementThatContainsPanels)
        {
            while (true)
            {
                if (elementThatContainsPanels != null && elementThatContainsPanels.Controls != null)
                {
                    foreach (var control in elementThatContainsPanels.Controls)
                    {
                        if (!(control is AccountInfoPanelUserControl)) continue;
                        var panel = control as AccountInfoPanelUserControl;

                        if (panel.AccountType == ConstantsController.ACCOUNT_TYPE_STRING_MARKET)
                        {
                            panel.RefreshMarketStatus();
                        }
                    }
                }

                Thread.Sleep(REFRESH_ALL_MARKET_PANELS_TIMEOUT_MS);
            }
        }
    }
}
