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
        public AutoMarketUserControl()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Properties.Settings.Default.MAFilesPath) ||
                DBController.PlayingAccounts.Count + DBController.BufferAccounts.Count + DBController.MarketAccounts.Count == 0
               )
            {
                this.Visible = false;
            }
        }
    }
}
