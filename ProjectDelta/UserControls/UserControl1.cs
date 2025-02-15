using ProjectDelta.Controllers;
using ProjectDelta.Tools;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();

            foreach (var item in DBController.BufferAccounts) listBox1.Items.Add(item.Value.AccountName);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var account = DBController.BufferAccounts.FirstOrDefault(x => x.Value.AccountName == textBoxUsername.Text).Value;
                if (account == null)
                {
                    MessageBox.Show("The account was not found!");
                    return;
                }

                MessageBox.Show(account.Session.IsRefreshTokenExpired().ToString() + " " + account.Session.IsAccessTokenExpired().ToString());

                textBoxSteamID.Text = account.Session.SteamID.ToString();

                if (account.Session.IsAccessTokenExpired())
                {
                    await account.Session.RefreshAccessToken();
                    ManifestSDAController manifest = ManifestSDAController.GetManifest();
                    if (!manifest.SaveAccount(account, ConstantsController.MA_FILES_PASSKEY != null, B64X.Decrypt(ConstantsController.MA_FILES_PASSKEY)))
                    {
                        manifest.RemoveAccount(account);
                    }
                }

                MessageBox.Show(account.AccountName);

                var confirmations = await account.FetchConfirmationsAsync();

                MessageBox.Show(confirmations.Length.ToString()); // Length: "0"

                //account.AcceptConfirmation();
                // nVxAiEcG9LR6Xl6a7yOTZdvEg6ck802
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
