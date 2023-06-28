using System;
using System.Windows.Forms;

namespace ProjectDelta
{
    public partial class CheckLicenseForm : Form
    {
        public CheckLicenseForm()
        {
            InitializeComponent();
            FormClosing += CheckLicenseForm_FormClosing;
        }

        private void CheckLicenseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
