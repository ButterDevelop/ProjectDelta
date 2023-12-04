using ProjectDelta.Controllers;
using System;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class AutoMarketUserControl : UserControl
    {
        private Thread _marketRefreshStatusThread;

        public AutoMarketUserControl()
        {
            InitializeComponent();
        }

        private void AutoMarketUserControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.MAFilesPath) ||
                DBController.PlayingAccounts.Count + DBController.BufferAccounts.Count + DBController.MarketAccounts.Count == 0
               )
            {
                this.Visible = false;
            }

            foreach (var panel in AccountInfoPanelUserControl.GetUIAccountsPanels(DBController.MarketAccounts))
            {
                flowLayoutPanelAutoMarket.Controls.Add(panel);
            }

            _marketRefreshStatusThread = new Thread(() => AccountInfoPanelUserControl.RefreshAllMarketStatusesInControl(flowLayoutPanelAutoMarket));
            _marketRefreshStatusThread.Start();
            Thread.Sleep(100);
        }
    }
}
