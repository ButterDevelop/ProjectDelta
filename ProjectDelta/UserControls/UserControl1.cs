using ProjectDelta.Controllers;
using ProjectDelta.Tools;
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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
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

                if (account.Session.IsAccessTokenExpired())
                {
                    await account.Session.RefreshAccessToken();
                    ManifestSDAController manifest = ManifestSDAController.GetManifest();
                    if (!manifest.SaveAccount(account, DBController.MA_FILES_PASSKEY != null, B64X.Decrypt(DBController.MA_FILES_PASSKEY)))
                    {
                        manifest.RemoveAccount(account);
                    }
                }

                MessageBox.Show(account.AccountName);

                var confirmations = await account.FetchConfirmationsAsync();

                MessageBox.Show(confirmations.Length.ToString()); // Length: "0"
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
