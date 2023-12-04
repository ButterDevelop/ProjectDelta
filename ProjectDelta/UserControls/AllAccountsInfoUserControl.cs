using ProjectDelta.Controllers;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta.UserControls
{
    public partial class AllAccountsInfoUserControl : UserControl
    {
        private Thread _marketAccountsRefreshStatusThread;

        public AllAccountsInfoUserControl()
        {
            InitializeComponent();
        }

        private void AllAccountsInfoUserControl_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default.MAFilesPath) ||
                DBController.PlayingAccounts.Count + DBController.BufferAccounts.Count + DBController.MarketAccounts.Count == 0
               )
            {
                this.Visible = false;
            }

            vScrollBarAccounts.Scroll += VScrollBarAccounts_Scroll;

            var allAccounts = DBController.PlayingAccounts.Concat(DBController.MarketAccounts).ToDictionary(pair => pair.Key, pair => pair.Value);
            allAccounts = allAccounts.Concat(DBController.BufferAccounts).ToDictionary(pair => pair.Key, pair => pair.Value);

            DoubleBufferedFlowLayoutPanel dbFlowLayoutPanelAccounts = new DoubleBufferedFlowLayoutPanel();
            dbFlowLayoutPanelAccounts.Location = new Point(0, 100);
            dbFlowLayoutPanelAccounts.Size = new Size(700, 550);
            dbFlowLayoutPanelAccounts.FlowDirection = FlowDirection.TopDown;
            dbFlowLayoutPanelAccounts.Dock = DockStyle.Bottom;
            dbFlowLayoutPanelAccounts.AutoScroll = true;
            this.Controls.Add(dbFlowLayoutPanelAccounts);

            foreach (var panel in AccountInfoPanelUserControl.GetUIAccountsPanels(allAccounts))
            {
                dbFlowLayoutPanelAccounts.Controls.Add(panel);
            }

            _marketAccountsRefreshStatusThread = new Thread(() => AccountInfoPanelUserControl.RefreshAllMarketStatusesInControl(dbFlowLayoutPanelAccounts));
            _marketAccountsRefreshStatusThread.Start();
            Thread.Sleep(100);
        }

        private void VScrollBarAccounts_Scroll(object sender, ScrollEventArgs e)
        {
            // Обновим AutoScrollPosition FlowLayoutPanel в зависимости от значения ScrollBar
            flowLayoutPanelAccounts.AutoScrollPosition = new Point(0, e.NewValue);
        }
    }
}
