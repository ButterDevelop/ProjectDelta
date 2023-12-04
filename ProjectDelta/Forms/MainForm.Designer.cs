namespace ProjectDelta.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTest = new System.Windows.Forms.TabPage();
            this.tabPageAutoMarket = new System.Windows.Forms.TabPage();
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket = new System.Windows.Forms.Label();
            this.tabPageAllAccountsInfo = new System.Windows.Forms.TabPage();
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo = new System.Windows.Forms.Label();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageAutoMarket.SuspendLayout();
            this.tabPageAllAccountsInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTest);
            this.tabControl.Controls.Add(this.tabPageAutoMarket);
            this.tabControl.Controls.Add(this.tabPageAllAccountsInfo);
            this.tabControl.Controls.Add(this.tabPageSettings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(878, 694);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageTest
            // 
            this.tabPageTest.Location = new System.Drawing.Point(4, 34);
            this.tabPageTest.Name = "tabPageTest";
            this.tabPageTest.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTest.Size = new System.Drawing.Size(870, 656);
            this.tabPageTest.TabIndex = 0;
            this.tabPageTest.Text = "Test tab";
            this.tabPageTest.UseVisualStyleBackColor = true;
            // 
            // tabPageAutoMarket
            // 
            this.tabPageAutoMarket.Controls.Add(this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket);
            this.tabPageAutoMarket.Location = new System.Drawing.Point(4, 34);
            this.tabPageAutoMarket.Name = "tabPageAutoMarket";
            this.tabPageAutoMarket.Size = new System.Drawing.Size(870, 656);
            this.tabPageAutoMarket.TabIndex = 2;
            this.tabPageAutoMarket.Text = "Auto market";
            this.tabPageAutoMarket.UseVisualStyleBackColor = true;
            // 
            // labelBackgroundTextAccountsWereNotLoaded_AutoMarket
            // 
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.Name = "labelBackgroundTextAccountsWereNotLoaded_AutoMarket";
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.Size = new System.Drawing.Size(870, 656);
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.TabIndex = 0;
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.Text = "You see this message because the function you have entered is disabled.\r\n\r\nThe St" +
    "eam accounts were not loaded or MA files path was not specified.\r\n\r\nPlease check" +
    " the settings and restart the app.\r\n";
            this.labelBackgroundTextAccountsWereNotLoaded_AutoMarket.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageAllAccountsInfo
            // 
            this.tabPageAllAccountsInfo.Controls.Add(this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo);
            this.tabPageAllAccountsInfo.Location = new System.Drawing.Point(4, 34);
            this.tabPageAllAccountsInfo.Name = "tabPageAllAccountsInfo";
            this.tabPageAllAccountsInfo.Size = new System.Drawing.Size(870, 656);
            this.tabPageAllAccountsInfo.TabIndex = 3;
            this.tabPageAllAccountsInfo.Text = "All accounts info";
            this.tabPageAllAccountsInfo.UseVisualStyleBackColor = true;
            // 
            // labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo
            // 
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.Location = new System.Drawing.Point(0, 0);
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.Name = "labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo";
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.Size = new System.Drawing.Size(870, 656);
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.TabIndex = 1;
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.Text = "You see this message because the function you have entered is disabled.\r\n\r\nThe St" +
    "eam accounts were not loaded or MA files path was not specified.\r\n\r\nPlease check" +
    " the settings and restart the app.\r\n";
            this.labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Location = new System.Drawing.Point(4, 34);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(870, 656);
            this.tabPageSettings.TabIndex = 1;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(878, 694);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Delta 1.0.0.0 by ButterDevelop";
            this.tabControl.ResumeLayout(false);
            this.tabPageAutoMarket.ResumeLayout(false);
            this.tabPageAllAccountsInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTest;
        private System.Windows.Forms.TabPage tabPageSettings;
        private System.Windows.Forms.TabPage tabPageAutoMarket;
        private System.Windows.Forms.Label labelBackgroundTextAccountsWereNotLoaded_AutoMarket;
        private System.Windows.Forms.TabPage tabPageAllAccountsInfo;
        private System.Windows.Forms.Label labelBackgroundTextAccountsWereNotLoaded_AllAccountsInfo;
    }
}

