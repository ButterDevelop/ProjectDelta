using ProjectDelta.Controllers;
using SteamAuth;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class SettingsUserControl : UserControl
    {
        public static string MAFilesPath = "";

        public SettingsUserControl()
        {
            InitializeComponent();

            MAFilesPath = Properties.Settings.Default.MAFilesPath;
            textBoxMAFilesPath.Text = MAFilesPath;

            //Set data from the db to the correct fields
            foreach (var marketAccountSteamId in DBController.MarketAccountsSteamIDs)
            {
                listBoxMarketAccounts.Items.Add(marketAccountSteamId);
                var marketApiKey = DBController.MarketAccountsAPIKeys[marketAccountSteamId];
                listBoxMarketAPIKeys.Items.Add(MarketAPIController.GetCensoredAPIKeyString(marketApiKey));
            }
            foreach (var playingAccountSteamId in DBController.PlayingAccountsSteamIDs)
            {
                listBoxPlayingAccounts.Items.Add(playingAccountSteamId);
            }

            listBoxMarketAccounts.SelectedIndexChanged += listBoxMarketAccounts_SelectedIndexChanged;
            listBoxMarketAPIKeys.SelectedIndexChanged += listBoxMarketAPIKeys_SelectedIndexChanged;
        }

        private void listBoxMarketAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMarketAccounts.SelectedItem is null) return;

            var index = listBoxMarketAccounts.SelectedIndex;
            listBoxMarketAPIKeys.SelectedIndex = index;
            listBoxMarketAPIKeys.Refresh();
        }
        private void listBoxMarketAPIKeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxMarketAPIKeys.SelectedItem is null) return;

            var index = listBoxMarketAPIKeys.SelectedIndex;
            listBoxMarketAccounts.SelectedIndex = index;
            listBoxMarketAccounts.Refresh();
        }

        private void buttonMAFilesPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            if (openFolderDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            textBoxMAFilesPath.Text = openFolderDialog.SelectedPath;
            MAFilesPath = openFolderDialog.SelectedPath;
        }

        private void buttonSaveSettings_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MAFilesPath))
            {
                MessageBox.Show("Your path to MA files is not specified!", "Error while saving settings!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default.MAFilesPath = MAFilesPath;

            Properties.Settings.Default.Save();

            MessageBox.Show("Your settings were saved successfully!", "Saved settings!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAddMarketAccount_Click(object sender, EventArgs e)
        {
            var steamId = textBoxSteamIDMarketAccounts.Text;
            var apiKey = textBoxAPIKeyMarketAccounts.Text;

            if (steamId.Length == 0)
            {
                MessageBox.Show("Your SteamID64 field is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            
            if (!steamId.StartsWith("765") || steamId.Length != 17)
            {
                MessageBox.Show("The SteamID64 you have specified seems incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listBoxMarketAccounts.Items.Contains(steamId))
            {
                MessageBox.Show("The list already contains this SteamID64!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (apiKey.Length == 0)
            {
                MessageBox.Show("Your Market API key field is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (apiKey.Length != 31)
            {
                MessageBox.Show("The Market API key you have specified seems incorrect!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (listBoxMarketAPIKeys.Items.Contains(apiKey))
            {
                MessageBox.Show("The list already contains this Market API key!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxMarketAccounts.Items.Add(steamId);
            listBoxMarketAPIKeys.Items.Add(MarketAPIController.GetCensoredAPIKeyString(apiKey));
            textBoxSteamIDMarketAccounts.Text = "";
            textBoxAPIKeyMarketAccounts.Text = "";
            listBoxMarketAccounts.Refresh();
            listBoxMarketAPIKeys.Refresh();

            DBController.MarketAccountsSteamIDs.Add(steamId);
            DBController.MarketAccountsAPIKeys.Add(steamId, apiKey);

            MessageBox.Show("The element was added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDeleteChosenMarketAccount_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Are you sure you want to delete this element?", "Sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.No) return;

            if (listBoxMarketAccounts.SelectedItem as string == null)
            {
                MessageBox.Show("No element was chosen!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var index = listBoxMarketAPIKeys.SelectedIndex;
            var steamId = listBoxMarketAccounts.SelectedItem as string;
            var apiKey = DBController.MarketAccountsAPIKeys[steamId];
            listBoxMarketAccounts.Items.Remove(steamId);
            listBoxMarketAccounts.Refresh();
            listBoxMarketAPIKeys.Items.RemoveAt(index);
            listBoxMarketAPIKeys.Refresh();

            DBController.MarketAccountsSteamIDs.Remove(steamId);
            DBController.MarketAccountsAPIKeys.Remove(apiKey);

            MessageBox.Show("The element was deleted successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonAddPlayingAccount_Click(object sender, EventArgs e)
        {
            var item = textBoxSteamIDPlayingAccounts.Text;

            if (item.Length == 0)
            {
                MessageBox.Show("Your SteamID64 field is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (listBoxPlayingAccounts.Items.Contains(item))
            {
                MessageBox.Show("The list already contains this SteamID64!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxPlayingAccounts.Items.Add(item);
            textBoxSteamIDPlayingAccounts.Text = "";
            listBoxPlayingAccounts.Refresh();

            DBController.PlayingAccountsSteamIDs.Add(item);

            MessageBox.Show("The element was added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDeleteChosenPlayingAccount_Click(object sender, EventArgs e)
        {
            if (listBoxPlayingAccounts.SelectedItem as string == null)
            {
                MessageBox.Show("No element was chosen!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = listBoxPlayingAccounts.SelectedItem as string;
            listBoxPlayingAccounts.Items.Remove(item);
            listBoxPlayingAccounts.Refresh();

            DBController.PlayingAccountsSteamIDs.Remove(item);

            MessageBox.Show("The element was deleted successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
