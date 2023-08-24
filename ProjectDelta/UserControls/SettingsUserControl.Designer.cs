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
            this.listBoxSellersAccounts = new System.Windows.Forms.ListBox();
            this.groupBoxSellersAccounts = new System.Windows.Forms.GroupBox();
            this.labelSellersAccountArrow = new System.Windows.Forms.Label();
            this.labelSellersAccounts = new System.Windows.Forms.Label();
            this.buttonDeleteChosenSellerAccount = new System.Windows.Forms.Button();
            this.buttonAddSellerAccount = new System.Windows.Forms.Button();
            this.textBoxSteamIDSellersAccounts = new System.Windows.Forms.TextBox();
            this.groupBoxMAFilesPath.SuspendLayout();
            this.groupBoxSellersAccounts.SuspendLayout();
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
            this.buttonSaveSettings.Location = new System.Drawing.Point(275, 540);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(150, 40);
            this.buttonSaveSettings.TabIndex = 2;
            this.buttonSaveSettings.Text = "Save settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // listBoxSellersAccounts
            // 
            this.listBoxSellersAccounts.BackColor = System.Drawing.Color.MintCream;
            this.listBoxSellersAccounts.FormattingEnabled = true;
            this.listBoxSellersAccounts.ItemHeight = 25;
            this.listBoxSellersAccounts.Location = new System.Drawing.Point(395, 30);
            this.listBoxSellersAccounts.Name = "listBoxSellersAccounts";
            this.listBoxSellersAccounts.Size = new System.Drawing.Size(219, 154);
            this.listBoxSellersAccounts.TabIndex = 5;
            // 
            // groupBoxSellersAccounts
            // 
            this.groupBoxSellersAccounts.Controls.Add(this.labelSellersAccountArrow);
            this.groupBoxSellersAccounts.Controls.Add(this.labelSellersAccounts);
            this.groupBoxSellersAccounts.Controls.Add(this.buttonDeleteChosenSellerAccount);
            this.groupBoxSellersAccounts.Controls.Add(this.buttonAddSellerAccount);
            this.groupBoxSellersAccounts.Controls.Add(this.textBoxSteamIDSellersAccounts);
            this.groupBoxSellersAccounts.Controls.Add(this.listBoxSellersAccounts);
            this.groupBoxSellersAccounts.Location = new System.Drawing.Point(27, 122);
            this.groupBoxSellersAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxSellersAccounts.Name = "groupBoxSellersAccounts";
            this.groupBoxSellersAccounts.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxSellersAccounts.Size = new System.Drawing.Size(636, 202);
            this.groupBoxSellersAccounts.TabIndex = 4;
            this.groupBoxSellersAccounts.TabStop = false;
            this.groupBoxSellersAccounts.Text = "Sellers accounts SteamID64";
            // 
            // labelSellersAccountArrow
            // 
            this.labelSellersAccountArrow.AutoSize = true;
            this.labelSellersAccountArrow.BackColor = System.Drawing.Color.Transparent;
            this.labelSellersAccountArrow.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSellersAccountArrow.Location = new System.Drawing.Point(278, 77);
            this.labelSellersAccountArrow.Name = "labelSellersAccountArrow";
            this.labelSellersAccountArrow.Size = new System.Drawing.Size(93, 64);
            this.labelSellersAccountArrow.TabIndex = 8;
            this.labelSellersAccountArrow.Text = "=>";
            // 
            // labelSellersAccounts
            // 
            this.labelSellersAccounts.Location = new System.Drawing.Point(23, 30);
            this.labelSellersAccounts.Name = "labelSellersAccounts";
            this.labelSellersAccounts.Size = new System.Drawing.Size(232, 20);
            this.labelSellersAccounts.TabIndex = 7;
            this.labelSellersAccounts.Text = "Steam ID:";
            this.labelSellersAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonDeleteChosenSellerAccount
            // 
            this.buttonDeleteChosenSellerAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonDeleteChosenSellerAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonDeleteChosenSellerAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeleteChosenSellerAccount.Location = new System.Drawing.Point(23, 149);
            this.buttonDeleteChosenSellerAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDeleteChosenSellerAccount.Name = "buttonDeleteChosenSellerAccount";
            this.buttonDeleteChosenSellerAccount.Size = new System.Drawing.Size(232, 35);
            this.buttonDeleteChosenSellerAccount.TabIndex = 4;
            this.buttonDeleteChosenSellerAccount.Text = "Delete chosen SteamID";
            this.buttonDeleteChosenSellerAccount.UseVisualStyleBackColor = true;
            this.buttonDeleteChosenSellerAccount.Click += new System.EventHandler(this.buttonDeleteChosenSellerAccount_Click);
            // 
            // buttonAddSellerAccount
            // 
            this.buttonAddSellerAccount.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.buttonAddSellerAccount.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.buttonAddSellerAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddSellerAccount.Location = new System.Drawing.Point(23, 104);
            this.buttonAddSellerAccount.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAddSellerAccount.Name = "buttonAddSellerAccount";
            this.buttonAddSellerAccount.Size = new System.Drawing.Size(232, 35);
            this.buttonAddSellerAccount.TabIndex = 3;
            this.buttonAddSellerAccount.Text = "Add this SteamID to list";
            this.buttonAddSellerAccount.UseVisualStyleBackColor = true;
            this.buttonAddSellerAccount.Click += new System.EventHandler(this.buttonAddSellerAccount_Click);
            // 
            // textBoxSteamIDSellersAccounts
            // 
            this.textBoxSteamIDSellersAccounts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSteamIDSellersAccounts.Location = new System.Drawing.Point(23, 54);
            this.textBoxSteamIDSellersAccounts.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSteamIDSellersAccounts.Name = "textBoxSteamIDSellersAccounts";
            this.textBoxSteamIDSellersAccounts.Size = new System.Drawing.Size(232, 30);
            this.textBoxSteamIDSellersAccounts.TabIndex = 2;
            this.textBoxSteamIDSellersAccounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.groupBoxSellersAccounts);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxMAFilesPath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(700, 600);
            this.groupBoxMAFilesPath.ResumeLayout(false);
            this.groupBoxMAFilesPath.PerformLayout();
            this.groupBoxSellersAccounts.ResumeLayout(false);
            this.groupBoxSellersAccounts.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMAFilesPath;
        private System.Windows.Forms.Label labelMAFilesPath;
        private System.Windows.Forms.GroupBox groupBoxMAFilesPath;
        private System.Windows.Forms.Button buttonMAFilesPath;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.ListBox listBoxSellersAccounts;
        private System.Windows.Forms.GroupBox groupBoxSellersAccounts;
        private System.Windows.Forms.TextBox textBoxSteamIDSellersAccounts;
        private System.Windows.Forms.Label labelSellersAccounts;
        private System.Windows.Forms.Button buttonDeleteChosenSellerAccount;
        private System.Windows.Forms.Button buttonAddSellerAccount;
        private System.Windows.Forms.Label labelSellersAccountArrow;
    }
}
