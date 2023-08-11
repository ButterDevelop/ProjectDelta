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
    }
}
