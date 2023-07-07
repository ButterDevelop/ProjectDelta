using ProjectDelta.Tools;
using System;
using System.Windows.Forms;

namespace ProjectDelta.Forms
{
    public partial class ShowKey : Form
    {
        public ShowKey()
        {
            InitializeComponent();
            FormClosing += ShowKey_FormClosing;
            textBoxNewID.Text = ID.NewIDNumber;

            if (Program.silent) this.Close();
        }

        private void ShowKey_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
