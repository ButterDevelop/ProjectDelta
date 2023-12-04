using ProjectDelta.Controllers;
using ProjectDelta.UserControls;
using System;
using System.Windows.Forms;

namespace ProjectDelta.Forms
{
    public partial class MainForm : Form
    {
        public static UserControl1 userControl1 = new UserControl1();
        public static AutoMarketUserControl autoMarketUserControl = new AutoMarketUserControl();
        public static AllAccountsInfoUserControl allAccountsInfoUserControl = new AllAccountsInfoUserControl();
        public static SettingsUserControl settingsUserControl = new SettingsUserControl();

        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;

            tabPageAutoMarket.Controls.Add(autoMarketUserControl);
            tabPageTest.Controls.Add(userControl1);
            tabPageAllAccountsInfo.Controls.Add(allAccountsInfoUserControl);
            tabPageSettings.Controls.Add(settingsUserControl);

            autoMarketUserControl.BringToFront();
            userControl1.BringToFront();
            allAccountsInfoUserControl.BringToFront();
            settingsUserControl.BringToFront();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to exit the program?", "Project Delta: Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                DBController.SaveJSON();
                Environment.Exit(0);
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
}
