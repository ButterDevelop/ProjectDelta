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
            var item = textBoxSteamIDMarketAccounts.Text;

            if (item.Length == 0)
            {
                MessageBox.Show("Your SteamID64 field is empty!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }            

            if (listBoxMarketAccounts.Items.Contains(item))
            {
                MessageBox.Show("The list already contains this SteamID64!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            listBoxMarketAccounts.Items.Add(item);
            textBoxSteamIDMarketAccounts.Text = "";
            listBoxMarketAccounts.Refresh();

            DBController.MarketAccountsSteamIDs.Add(item);

            MessageBox.Show("The element was added successfully.", "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonDeleteChosenMarketAccount_Click(object sender, EventArgs e)
        {
            if (listBoxMarketAccounts.SelectedItem as string == null)
            {
                MessageBox.Show("No element was chosen!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var item = listBoxMarketAccounts.SelectedItem as string;
            listBoxMarketAccounts.Items.Remove(item);
            listBoxMarketAccounts.Refresh();

            DBController.MarketAccountsSteamIDs.Remove(item);

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
