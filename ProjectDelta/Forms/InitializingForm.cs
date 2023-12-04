using ProjectDelta.Controllers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ProjectDelta.Forms
{
    public partial class InitializingForm : Form
    {
        private static readonly int TIMEOUT_FOR_CLOSING_MS = 5000;
        private static readonly Color GOOD_COLOR    = Color.Blue;
        private static readonly Color WARNING_COLOR = Color.Gold;
        private static readonly Color BAD_COLOR     = Color.Red;
        private static readonly Color DEFAULT_COLOR = Color.Black;

        public static bool ShutDownForm = false;
        public bool localShutDownForm = false;

        private Dictionary<Label, string> _goodLabelMessages = new Dictionary<Label, string>();

        public InitializingForm()
        {
            InitializeComponent();
        }

        private void InitializingForm_Load(object sender, EventArgs e)
        {
            ShutDownForm = false;
            localShutDownForm = false;

            label1.ForeColor = DEFAULT_COLOR;
            label2.ForeColor = DEFAULT_COLOR;
            label3.ForeColor = DEFAULT_COLOR;
            label4.ForeColor = DEFAULT_COLOR;
            label5.ForeColor = DEFAULT_COLOR;
            label6.ForeColor = DEFAULT_COLOR;

            FormClosing += InitializingForm_FormClosing;

            _goodLabelMessages.Add(label1, "Got the encryption keys.");
            _goodLabelMessages.Add(label2, "Loaded the database data.");
            _goodLabelMessages.Add(label3, "Initialized the HTTP client.");
            _goodLabelMessages.Add(label4, "Loaded MA files.");
            _goodLabelMessages.Add(label5, "Loaded Steam web profiles.");
            _goodLabelMessages.Add(label6, "Started the program.");

            if (!Program.silent)
            {
                new Thread(() => AnimateLabelsText()).Start();
                Thread.Sleep(250);
                new Thread(() => DoInitializeWork()).Start();
                Thread.Sleep(250);
            }
        }

        private void InitializingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        public void AnimateLabelsText()
        {
            Thread.Sleep(1000);

            int currentAnimationStep = 0;

            while (!localShutDownForm)
            {
                AnimateOneLabel(label1, currentAnimationStep);
                AnimateOneLabel(label2, currentAnimationStep);
                AnimateOneLabel(label3, currentAnimationStep);
                AnimateOneLabel(label4, currentAnimationStep);
                AnimateOneLabel(label5, currentAnimationStep);
                AnimateOneLabel(label6, currentAnimationStep);

                ++currentAnimationStep;
                currentAnimationStep %= "...".Length * 2;
                Thread.Sleep(1000);
            }
        }
        public void AnimateOneLabel(Label label, int currentAnimationStep)
        {
            if (label.ForeColor == DEFAULT_COLOR)
            {
                string new_text = label.Text;
                if (currentAnimationStep < 3)
                {
                    new_text = new_text.Remove(new_text.Length - 1);
                }
                else
                {
                    new_text += ".";
                }

                UpdateLabel(label, new_text, label.ForeColor);
            }
        }

        public void DoInitializeWork()
        {
            //MessageBox.Show("After you click the \"OK\" button, the accounts loading will be started. This action can take up to a few minutes.", "Project Delta: Attention please!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //MessageBox.Show("Unable to load encryption keys!", "Project Delta: Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //MessageBox.Show("The database was not loaded or was empty.", "Project Delta: Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //MessageBox.Show("The Steam accounts were not loaded or the folder is empty.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //MessageBox.Show("The Steam Accounts info was not loaded! The next try will be there soon if it is necessary.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            Thread.Sleep(1000);

            // 1
            if (DBController.GetEncryptionKey())
            {
                UpdateLabelColorGood(label1);
            }
            else
            {
                UpdateLabelColorBad(label1);
                CloseFullApp(TIMEOUT_FOR_CLOSING_MS);
            }

            // 2
            if (DBController.LoadData())
            {
                UpdateLabelColorGood(label2);
            }
            else
            {
                UpdateLabelColorWarning(label2);
            }

            // 3
            HTTPRequestController.Initialize();
            UpdateLabelColorGood(label3);

            // 4
            string maFilesFolderPath = Properties.Settings.Default.MAFilesPath;
            if (string.IsNullOrEmpty(maFilesFolderPath) || !Directory.Exists(maFilesFolderPath)
                || !File.Exists(Path.Combine(maFilesFolderPath, ConstantsController.MA_MANIFEST_FILE_NAME)) || !DBController.LoadSteamAccountsData())
            {
                UpdateLabelColorWarning(label4);
            }
            else
            {
                UpdateLabelColorGood(label4);
            }

            // 5
            if (DBController.LoadSteamWebProfiles())
            {
                UpdateLabelColorGood(label5);
            }
            else
            {
                UpdateLabelColorWarning(label5);
            }

            //6
            Thread.Sleep(1000);
            UpdateLabelColorGood(label6);

            // The last action
            CloseForm();
        }

        private void UpdateLabelColorGood(Label label)
        {
            string new_text = _goodLabelMessages.ContainsKey(label) ? _goodLabelMessages[label] : label.Text;
            UpdateLabel(label, $"✔ [{DateTime.Now}] " + new_text, GOOD_COLOR);
        }
        private void UpdateLabelColorWarning(Label label)
        {
            UpdateLabel(label, $"● [{DateTime.Now}] " + label.Text, WARNING_COLOR);
        }
        private void UpdateLabelColorBad(Label label)
        {
            UpdateLabel(label, $"✘ [{DateTime.Now}] " + label.Text, BAD_COLOR);
        }

        private void UpdateLabel(Label label, string text, Color color)
        {
            if (label.InvokeRequired)
            {
                // Если это не основной поток, вызываем метод снова через Invoke
                this.Invoke(new Action<Label, string, Color>(UpdateLabel), label, text, color);
            }
            else
            {
                // Это основной поток, можно обновить Label
                label.Text = text;
                label.ForeColor = color;
            }
        }

        private void CloseForm()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(CloseForm));
            }
            else
            {
                localShutDownForm = true;
                Thread.Sleep(TIMEOUT_FOR_CLOSING_MS);
                ShutDownForm = true;
                Thread.Sleep(TIMEOUT_FOR_CLOSING_MS);
                // The main thread will not start MainForm for some reason if this form is closed.
                // this.Close();
            }
        }

        private void CloseFullApp(int timeoutMs)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action<int>(CloseFullApp), timeoutMs);
            }
            else
            {
                ShutDownForm = true;
                Thread.Sleep(timeoutMs);
                Environment.Exit(0);
            }
        }


        public static void StartNewInitForm()
        {
            try
            {
                var initForm = new InitializingForm();
                if (!Program.silent)
                {
                    initForm.ShowDialog();
                }
                else
                {
                    initForm.DoInitializeWork();
                }
            }
            catch { }
        }
    }
}
