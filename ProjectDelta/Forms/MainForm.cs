using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectDelta.UserControls;

namespace ProjectDelta.Forms
{
    public partial class MainForm : Form
    {
        public static SettingsUserControl settingsUserControl = new SettingsUserControl();

        public MainForm()
        {
            InitializeComponent();

            tabPageSettings.Controls.Add(settingsUserControl);
        }
    }
}
