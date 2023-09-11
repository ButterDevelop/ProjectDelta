namespace ProjectDelta.UserControls
{
    partial class SettingsUserControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxMAFilesPath = new System.Windows.Forms.TextBox();
            this.labelMAFilesPath = new System.Windows.Forms.Label();
            this.groupBoxMAFilesPath = new System.Windows.Forms.GroupBox();
            this.buttonMAFilesPath = new System.Windows.Forms.Button();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.listBoxMarketAccounts = new System.Windows.Forms.ListBox();
            this.groupBoxMarketAccounts = new System.Windows.Forms.GroupBox();
            this.labelMarketAccountsAPI = new System.Windows.Forms.Label();
            this.textBoxAPIKeyMarketAccounts = new System.Windows.Forms.TextBox();
            this.listBoxMarketAPIKeys = new System.Windows.Forms.ListBox();
            this.labelMarketAccountArrow = new System.Windows.Forms.Label();
            this.labelMarketAccounts = new System.Windows.Forms.Label();
            this.buttonDeleteChosenMarketAccount = new System.Windows.Forms.Button();
            this.buttonAddMarketAccount = new System.Windows.Forms.Button();
            this.textBoxSteamIDMarketAccounts = new System.Windows.Forms.TextBox();
            this.groupBoxPlayingAccounts = new System.Windows.Forms.GroupBox();
            this.labelPlayingAccountArrow = new System.Windows.Forms.Label();
            this.labelPlayingAccounts = new System.Windows.Forms.Label();
            this.buttonDeleteChosenPlayingAccount = new System.Windows.Forms.Button();
            this.buttonAddPlayingAccount = new System.Windows.Forms.Button();
            this.textBoxSteamIDPlayingAccounts = new System.Windows.Forms.TextBox();
            this.listBoxPlayingAccounts = new System.Windows.Forms.ListBox();
            this.labelBufferAccounts = new System.Windows.Forms.Label();
            this.groupBoxMAFilesPath.SuspendLayout();
            this.groupBoxMarketAccounts.SuspendLayout();
            this.groupBoxPlayingAccounts.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxMAFilesPath
            // 
            this.textBoxMAFilesPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMAFilesPath.Location = new System.Drawing.Point(156, 45);
            this.textBoxMAFilesPath.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMAFilesPath.Name = "textBoxMAFilesPath";
            this.textBoxMAFilesPath.ReadOnly = true;
            this.textBoxMAFilesPath.Size = new System.Drawing.Size(406, 30);
            this.textBoxMAFilesPath.TabIndex = 0;
            // 
            // labelMAFilesPath
            // 
            this.labelMAFilesPath.AutoSize = true;
            this.labelMAFilesPath.Location = new System.Drawing.Point(23, 49);
            this.labelMAFilesPath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMAFilesPath.Name = "labelMAFilesPath";
            this.labelMAFilesPath.Size = new System.Drawing.Size(116, 25);
            this.labelMAFilesPath.TabIndex = 1;
            this.labelMAFilesPath.Text = "Folder path:";
            // 
            // groupBoxMAFilesPath
            // 
            this.groupBoxMAFilesPath.Controls.Add(this.buttonMAFilesPath);
            this.groupBoxMAFilesPath.Controls.Add(this.labelMAFilesPath);
            this.groupBoxMAFilesPath.Controls.Add(this.textBoxMAFilesPath);
            this.groupBoxMAFilesPath.Location = new System.Drawing.Point(27, 15);
            this.groupBoxMAFilesPath.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMAFilesPath.Name = "groupBoxMAFilesPath";
            this.groupBoxMAFilesPath.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMAFilesPath.Size = new System.Drawing.Size(636, 99);
            this.groupBoxMAFilesPath.TabIndex = 2;
            this.groupBoxMAFilesPath.TabStop = false;
            this.groupBoxMAFilesPath.Text = "Path to MA files";
            // 
            // buttonMAFilesPath
            // 
            this.buttonMAFilesPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonMAFilesPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonMAFilesPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMAFilesPath.Location = new System.Drawing.Point(570, 42);
            this.buttonMAFilesPath.Margin = new System.Windows.Forms.Padding(4);
            this.buttonMAFilesPath.Name = "buttonMAFilesPath";
            this.buttonMAFilesPath.Size = new System.Drawing.Size(44, 35);
            this.buttonMAFilesPath.TabIndex = 1;
            this.buttonMAFilesPath.Text = "...";
            this.buttonMAFilesPath.UseVisualStyleBackColor = true;
            this.buttonMAFilesPath.Click += new System.EventHandler(this.buttonMAFilesPath_Click);
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonSaveSettings.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonSaveSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSaveSettings.Location = new System.Drawing.Point(277, 597);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(150, 40);
            this.buttonSaveSettings.TabIndex = 2;
            this.buttonSaveSettings.Text = "Save settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // listBoxMarketAccounts
            // 
            this.listBoxMarketAccounts.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxMarketAccounts.FormattingEnabled = true;
            this.listBoxMarketAccounts.ItemHeight = 25;
            this.listBoxMarketAccounts.Location = new System.Drawing.Point(395, 30);
            this.listBoxMarketAccounts.Name = "listBoxMarketAccounts";
            this.listBoxMarketAccounts.Size = new System.Drawing.Size(219, 79);
            this.listBoxMarketAccounts.TabIndex = 5;
            // 
            // groupBoxMarketAccounts
            // 
            this.groupBoxMarketAccounts.Controls.Add(this.labelMarketAccountsAPI);
            this.groupBoxMarketAccounts.Controls.Add(this.textBoxAPIKeyMarketAccounts);
            this.groupBoxMarketAccounts.Controls.Add(this.listBoxMarketAPIKeys);
            this.groupBoxMarketAccounts.Controls.Add(this.labelMarketAccountArrow);
            this.groupBoxMarketAccounts.Controls.Add(this.labelMarketAccounts);
            this.groupBoxMarketAccounts.Controls.Add(this.buttonDeleteChosenMarketAccount);
            this.groupBoxMarketAccounts.Controls.Add(this.buttonAddMarketAccount);
            this.groupBoxMarketAccounts.Controls.Add(this.textBoxSteamIDMarketAccounts);
            this.groupBoxMarketAccounts.Controls.Add(this.listBoxMarketAccounts);
            this.groupBoxMarketAccounts.Location = new System.Drawing.Point(27, 122);
            this.groupBoxMarketAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxMarketAccounts.Name = "groupBoxMarketAccounts";
            this.groupBoxMarketAccounts.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxMarketAccounts.Size = new System.Drawing.Size(636, 202);
            this.groupBoxMarketAccounts.TabIndex = 4;
            this.groupBoxMarketAccounts.TabStop = false;
            this.groupBoxMarketAccounts.Text = "Market accounts SteamID64";
            // 
            // labelMarketAccountsAPI
            // 
            this.labelMarketAccountsAPI.Location = new System.Drawing.Point(23, 88);
            this.labelMarketAccountsAPI.Name = "labelMarketAccountsAPI";
            this.labelMarketAccountsAPI.Size = new System.Drawing.Size(232, 28);
            this.labelMarketAccountsAPI.TabIndex = 11;
            this.labelMarketAccountsAPI.Text = "Market API key:";
            this.labelMarketAccountsAPI.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAPIKeyMarketAccounts
            // 
            this.textBoxAPIKeyMarketAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAPIKeyMarketAccounts.Location = new System.Drawing.Point(23, 120);
            this.textBoxAPIKeyMarketAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAPIKeyMarketAccounts.Name = "textBoxAPIKeyMarketAccounts";
            this.textBoxAPIKeyMarketAccounts.Size = new System.Drawing.Size(232, 30);
            this.textBoxAPIKeyMarketAccounts.TabIndex = 10;
            this.textBoxAPIKeyMarketAccounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxMarketAPIKeys
            // 
            this.listBoxMarketAPIKeys.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxMarketAPIKeys.FormattingEnabled = true;
            this.listBoxMarketAPIKeys.ItemHeight = 25;
            this.listBoxMarketAPIKeys.Location = new System.Drawing.Point(395, 115);
            this.listBoxMarketAPIKeys.Name = "listBoxMarketAPIKeys";
            this.listBoxMarketAPIKeys.Size = new System.Drawing.Size(219, 79);
            this.listBoxMarketAPIKeys.TabIndex = 9;
            // 
            // labelMarketAccountArrow
            // 
            this.labelMarketAccountArrow.AutoSize = true;
            this.labelMarketAccountArrow.BackColor = System.Drawing.Color.Transparent;
            this.labelMarketAccountArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMarketAccountArrow.Location = new System.Drawing.Point(278, 77);
            this.labelMarketAccountArrow.Name = "labelMarketAccountArrow";
            this.labelMarketAccountArrow.Size = new System.Drawing.Size(93, 64);
            this.labelMarketAccountArrow.TabIndex = 8;
            this.labelMarketAccountArrow.Text = "=>";
            // 
            // labelMarketAccounts
            // 
            this.labelMarketAccounts.Location = new System.Drawing.Point(23, 30);
            this.labelMarketAccounts.Name = "labelMarketAccounts";
            this.labelMarketAccounts.Size = new System.Drawing.Size(232, 20);
            this.labelMarketAccounts.TabIndex = 7;
            this.labelMarketAccounts.Text = "Steam ID:";
            this.labelMarketAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteChosenMarketAccount
            // 
            this.buttonDeleteChosenMarketAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDeleteChosenMarketAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteChosenMarketAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteChosenMarketAccount.Location = new System.Drawing.Point(139, 159);
            this.buttonDeleteChosenMarketAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteChosenMarketAccount.Name = "buttonDeleteChosenMarketAccount";
            this.buttonDeleteChosenMarketAccount.Size = new System.Drawing.Size(116, 35);
            this.buttonDeleteChosenMarketAccount.TabIndex = 4;
            this.buttonDeleteChosenMarketAccount.Text = "Delete chosen SteamID";
            this.buttonDeleteChosenMarketAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteChosenMarketAccount.Click += new System.EventHandler(this.buttonDeleteChosenMarketAccount_Click);
            // 
            // buttonAddMarketAccount
            // 
            this.buttonAddMarketAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAddMarketAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddMarketAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddMarketAccount.Location = new System.Drawing.Point(23, 159);
            this.buttonAddMarketAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddMarketAccount.Name = "buttonAddMarketAccount";
            this.buttonAddMarketAccount.Size = new System.Drawing.Size(108, 35);
            this.buttonAddMarketAccount.TabIndex = 3;
            this.buttonAddMarketAccount.Text = "Add";
            this.buttonAddMarketAccount.UseVisualStyleBackColor = true;
            this.buttonAddMarketAccount.Click += new System.EventHandler(this.buttonAddMarketAccount_Click);
            // 
            // textBoxSteamIDMarketAccounts
            // 
            this.textBoxSteamIDMarketAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSteamIDMarketAccounts.Location = new System.Drawing.Point(23, 54);
            this.textBoxSteamIDMarketAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSteamIDMarketAccounts.Name = "textBoxSteamIDMarketAccounts";
            this.textBoxSteamIDMarketAccounts.Size = new System.Drawing.Size(232, 30);
            this.textBoxSteamIDMarketAccounts.TabIndex = 2;
            this.textBoxSteamIDMarketAccounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBoxPlayingAccounts
            // 
            this.groupBoxPlayingAccounts.Controls.Add(this.labelPlayingAccountArrow);
            this.groupBoxPlayingAccounts.Controls.Add(this.labelPlayingAccounts);
            this.groupBoxPlayingAccounts.Controls.Add(this.buttonDeleteChosenPlayingAccount);
            this.groupBoxPlayingAccounts.Controls.Add(this.buttonAddPlayingAccount);
            this.groupBoxPlayingAccounts.Controls.Add(this.textBoxSteamIDPlayingAccounts);
            this.groupBoxPlayingAccounts.Controls.Add(this.listBoxPlayingAccounts);
            this.groupBoxPlayingAccounts.Location = new System.Drawing.Point(27, 331);
            this.groupBoxPlayingAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxPlayingAccounts.Name = "groupBoxPlayingAccounts";
            this.groupBoxPlayingAccounts.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxPlayingAccounts.Size = new System.Drawing.Size(636, 202);
            this.groupBoxPlayingAccounts.TabIndex = 5;
            this.groupBoxPlayingAccounts.TabStop = false;
            this.groupBoxPlayingAccounts.Text = "Playing accounts SteamID64";
            // 
            // labelPlayingAccountArrow
            // 
            this.labelPlayingAccountArrow.AutoSize = true;
            this.labelPlayingAccountArrow.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayingAccountArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlayingAccountArrow.Location = new System.Drawing.Point(278, 77);
            this.labelPlayingAccountArrow.Name = "labelPlayingAccountArrow";
            this.labelPlayingAccountArrow.Size = new System.Drawing.Size(93, 64);
            this.labelPlayingAccountArrow.TabIndex = 8;
            this.labelPlayingAccountArrow.Text = "=>";
            // 
            // labelPlayingAccounts
            // 
            this.labelPlayingAccounts.Location = new System.Drawing.Point(23, 30);
            this.labelPlayingAccounts.Name = "labelPlayingAccounts";
            this.labelPlayingAccounts.Size = new System.Drawing.Size(232, 20);
            this.labelPlayingAccounts.TabIndex = 7;
            this.labelPlayingAccounts.Text = "Steam ID:";
            this.labelPlayingAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteChosenPlayingAccount
            // 
            this.buttonDeleteChosenPlayingAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDeleteChosenPlayingAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteChosenPlayingAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteChosenPlayingAccount.Location = new System.Drawing.Point(23, 149);
            this.buttonDeleteChosenPlayingAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteChosenPlayingAccount.Name = "buttonDeleteChosenPlayingAccount";
            this.buttonDeleteChosenPlayingAccount.Size = new System.Drawing.Size(232, 35);
            this.buttonDeleteChosenPlayingAccount.TabIndex = 4;
            this.buttonDeleteChosenPlayingAccount.Text = "Delete chosen SteamID";
            this.buttonDeleteChosenPlayingAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteChosenPlayingAccount.Click += new System.EventHandler(this.buttonDeleteChosenPlayingAccount_Click);
            // 
            // buttonAddPlayingAccount
            // 
            this.buttonAddPlayingAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAddPlayingAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddPlayingAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPlayingAccount.Location = new System.Drawing.Point(23, 104);
            this.buttonAddPlayingAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddPlayingAccount.Name = "buttonAddPlayingAccount";
            this.buttonAddPlayingAccount.Size = new System.Drawing.Size(232, 35);
            this.buttonAddPlayingAccount.TabIndex = 3;
            this.buttonAddPlayingAccount.Text = "Add this SteamID to list";
            this.buttonAddPlayingAccount.UseVisualStyleBackColor = true;
            this.buttonAddPlayingAccount.Click += new System.EventHandler(this.buttonAddPlayingAccount_Click);
            // 
            // textBoxSteamIDPlayingAccounts
            // 
            this.textBoxSteamIDPlayingAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSteamIDPlayingAccounts.Location = new System.Drawing.Point(23, 54);
            this.textBoxSteamIDPlayingAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSteamIDPlayingAccounts.Name = "textBoxSteamIDPlayingAccounts";
            this.textBoxSteamIDPlayingAccounts.Size = new System.Drawing.Size(232, 30);
            this.textBoxSteamIDPlayingAccounts.TabIndex = 2;
            this.textBoxSteamIDPlayingAccounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxPlayingAccounts
            // 
            this.listBoxPlayingAccounts.BackColor = System.Drawing.SystemColors.Window;
            this.listBoxPlayingAccounts.FormattingEnabled = true;
            this.listBoxPlayingAccounts.ItemHeight = 25;
            this.listBoxPlayingAccounts.Location = new System.Drawing.Point(395, 30);
            this.listBoxPlayingAccounts.Name = "listBoxPlayingAccounts";
            this.listBoxPlayingAccounts.Size = new System.Drawing.Size(219, 154);
            this.listBoxPlayingAccounts.TabIndex = 5;
            // 
            // labelBufferAccounts
            // 
            this.labelBufferAccounts.Location = new System.Drawing.Point(27, 537);
            this.labelBufferAccounts.Name = "labelBufferAccounts";
            this.labelBufferAccounts.Size = new System.Drawing.Size(636, 57);
            this.labelBufferAccounts.TabIndex = 8;
            this.labelBufferAccounts.Text = "The rest of accounts in the folder counted as the Buffer accounts.";
            this.labelBufferAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelBufferAccounts);
            this.Controls.Add(this.groupBoxPlayingAccounts);
            this.Controls.Add(this.groupBoxMarketAccounts);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxMAFilesPath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(700, 650);
            this.groupBoxMAFilesPath.ResumeLayout(false);
            this.groupBoxMAFilesPath.PerformLayout();
            this.groupBoxMarketAccounts.ResumeLayout(false);
            this.groupBoxMarketAccounts.PerformLayout();
            this.groupBoxPlayingAccounts.ResumeLayout(false);
            this.groupBoxPlayingAccounts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMAFilesPath;
        private System.Windows.Forms.Label labelMAFilesPath;
        private System.Windows.Forms.GroupBox groupBoxMAFilesPath;
        private System.Windows.Forms.Button buttonMAFilesPath;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.ListBox listBoxMarketAccounts;
        private System.Windows.Forms.GroupBox groupBoxMarketAccounts;
        private System.Windows.Forms.TextBox textBoxSteamIDMarketAccounts;
        private System.Windows.Forms.Label labelMarketAccounts;
        private System.Windows.Forms.Button buttonDeleteChosenMarketAccount;
        private System.Windows.Forms.Button buttonAddMarketAccount;
        private System.Windows.Forms.Label labelMarketAccountArrow;
        private System.Windows.Forms.GroupBox groupBoxPlayingAccounts;
        private System.Windows.Forms.Label labelPlayingAccountArrow;
        private System.Windows.Forms.Label labelPlayingAccounts;
        private System.Windows.Forms.Button buttonDeleteChosenPlayingAccount;
        private System.Windows.Forms.Button buttonAddPlayingAccount;
        private System.Windows.Forms.TextBox textBoxSteamIDPlayingAccounts;
        private System.Windows.Forms.ListBox listBoxPlayingAccounts;
        private System.Windows.Forms.Label labelBufferAccounts;
        private System.Windows.Forms.ListBox listBoxMarketAPIKeys;
        private System.Windows.Forms.Label labelMarketAccountsAPI;
        private System.Windows.Forms.TextBox textBoxAPIKeyMarketAccounts;
    }
}
