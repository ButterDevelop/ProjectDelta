using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectDelta.Controllers;
using ProjectDelta.UserControls;

namespace ProjectDelta.Forms
{
    public partial class MainForm : Form
    {
        public static AutoMarketUserControl autoMarketUserControl = new AutoMarketUserControl();
        public static UserControl1 userControl1 = new UserControl1();
        public static SettingsUserControl settingsUserControl = new SettingsUserControl();

        public MainForm()
        {
            InitializeComponent();

            this.FormClosing += MainForm_FormClosing;

            tabPageAutoMarket.Controls.Add(autoMarketUserControl);
            tabPageTest.Controls.Add(userControl1);
            tabPageSettings.Controls.Add(settingsUserControl);

            autoMarketUserControl.BringToFront();
            userControl1.BringToFront();
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
