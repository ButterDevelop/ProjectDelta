namespace ProjectDelta.UserControls
{
    partial class AccountInfoPanelUserControl
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
            this.textBoxSteamAccountName = new System.Windows.Forms.TextBox();
            this.pictureBoxSteamAccountAvatar = new System.Windows.Forms.PictureBox();
            this.labelSteamAccountName = new System.Windows.Forms.Label();
            this.labelSteamAccountLogin = new System.Windows.Forms.Label();
            this.textBoxSteamAccountLogin = new System.Windows.Forms.TextBox();
            this.labelAccountTypeInProgram = new System.Windows.Forms.Label();
            this.textBoxAccountTypeInProgram = new System.Windows.Forms.TextBox();
            this.labelAccountSteamID64 = new System.Windows.Forms.Label();
            this.textBoxAccountSteamID64 = new System.Windows.Forms.TextBox();
            this.textBoxMarketAPIKey = new System.Windows.Forms.TextBox();
            this.labelMarketAPIKey = new System.Windows.Forms.Label();
            this.labelMarketAPIKeyStatus = new System.Windows.Forms.Label();
            this.labelMarketAPIStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteamAccountAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxSteamAccountName
            // 
            this.textBoxSteamAccountName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSteamAccountName.Location = new System.Drawing.Point(127, 30);
            this.textBoxSteamAccountName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSteamAccountName.Name = "textBoxSteamAccountName";
            this.textBoxSteamAccountName.ReadOnly = true;
            this.textBoxSteamAccountName.Size = new System.Drawing.Size(140, 26);
            this.textBoxSteamAccountName.TabIndex = 3;
            this.textBoxSteamAccountName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pictureBoxSteamAccountAvatar
            // 
            this.pictureBoxSteamAccountAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxSteamAccountAvatar.Location = new System.Drawing.Point(10, 10);
            this.pictureBoxSteamAccountAvatar.Name = "pictureBoxSteamAccountAvatar";
            this.pictureBoxSteamAccountAvatar.Size = new System.Drawing.Size(100, 100);
            this.pictureBoxSteamAccountAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxSteamAccountAvatar.TabIndex = 4;
            this.pictureBoxSteamAccountAvatar.TabStop = false;
            // 
            // labelSteamAccountName
            // 
            this.labelSteamAccountName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSteamAccountName.Location = new System.Drawing.Point(127, 4);
            this.labelSteamAccountName.Name = "labelSteamAccountName";
            this.labelSteamAccountName.Size = new System.Drawing.Size(140, 22);
            this.labelSteamAccountName.TabIndex = 5;
            this.labelSteamAccountName.Text = "Account nick:";
            this.labelSteamAccountName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSteamAccountLogin
            // 
            this.labelSteamAccountLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelSteamAccountLogin.Location = new System.Drawing.Point(275, 4);
            this.labelSteamAccountLogin.Name = "labelSteamAccountLogin";
            this.labelSteamAccountLogin.Size = new System.Drawing.Size(140, 22);
            this.labelSteamAccountLogin.TabIndex = 7;
            this.labelSteamAccountLogin.Text = "Account login:";
            this.labelSteamAccountLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxSteamAccountLogin
            // 
            this.textBoxSteamAccountLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxSteamAccountLogin.Location = new System.Drawing.Point(275, 30);
            this.textBoxSteamAccountLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxSteamAccountLogin.Name = "textBoxSteamAccountLogin";
            this.textBoxSteamAccountLogin.ReadOnly = true;
            this.textBoxSteamAccountLogin.Size = new System.Drawing.Size(140, 26);
            this.textBoxSteamAccountLogin.TabIndex = 6;
            this.textBoxSteamAccountLogin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccountTypeInProgram
            // 
            this.labelAccountTypeInProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccountTypeInProgram.Location = new System.Drawing.Point(127, 57);
            this.labelAccountTypeInProgram.Name = "labelAccountTypeInProgram";
            this.labelAccountTypeInProgram.Size = new System.Drawing.Size(140, 23);
            this.labelAccountTypeInProgram.TabIndex = 8;
            this.labelAccountTypeInProgram.Text = "Account type:";
            this.labelAccountTypeInProgram.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountTypeInProgram
            // 
            this.textBoxAccountTypeInProgram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAccountTypeInProgram.Location = new System.Drawing.Point(127, 84);
            this.textBoxAccountTypeInProgram.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAccountTypeInProgram.Name = "textBoxAccountTypeInProgram";
            this.textBoxAccountTypeInProgram.ReadOnly = true;
            this.textBoxAccountTypeInProgram.Size = new System.Drawing.Size(140, 26);
            this.textBoxAccountTypeInProgram.TabIndex = 9;
            this.textBoxAccountTypeInProgram.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelAccountSteamID64
            // 
            this.labelAccountSteamID64.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAccountSteamID64.Location = new System.Drawing.Point(423, 4);
            this.labelAccountSteamID64.Name = "labelAccountSteamID64";
            this.labelAccountSteamID64.Size = new System.Drawing.Size(205, 22);
            this.labelAccountSteamID64.TabIndex = 11;
            this.labelAccountSteamID64.Text = "SteamID64:";
            this.labelAccountSteamID64.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxAccountSteamID64
            // 
            this.textBoxAccountSteamID64.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAccountSteamID64.Location = new System.Drawing.Point(423, 30);
            this.textBoxAccountSteamID64.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxAccountSteamID64.Name = "textBoxAccountSteamID64";
            this.textBoxAccountSteamID64.ReadOnly = true;
            this.textBoxAccountSteamID64.Size = new System.Drawing.Size(205, 26);
            this.textBoxAccountSteamID64.TabIndex = 10;
            this.textBoxAccountSteamID64.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxMarketAPIKey
            // 
            this.textBoxMarketAPIKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxMarketAPIKey.Location = new System.Drawing.Point(275, 84);
            this.textBoxMarketAPIKey.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxMarketAPIKey.Name = "textBoxMarketAPIKey";
            this.textBoxMarketAPIKey.ReadOnly = true;
            this.textBoxMarketAPIKey.Size = new System.Drawing.Size(140, 26);
            this.textBoxMarketAPIKey.TabIndex = 13;
            this.textBoxMarketAPIKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMarketAPIKey
            // 
            this.labelMarketAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMarketAPIKey.Location = new System.Drawing.Point(271, 59);
            this.labelMarketAPIKey.Name = "labelMarketAPIKey";
            this.labelMarketAPIKey.Size = new System.Drawing.Size(153, 21);
            this.labelMarketAPIKey.TabIndex = 12;
            this.labelMarketAPIKey.Text = "Market API key:";
            this.labelMarketAPIKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMarketAPIKeyStatus
            // 
            this.labelMarketAPIKeyStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMarketAPIKeyStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelMarketAPIKeyStatus.Location = new System.Drawing.Point(423, 84);
            this.labelMarketAPIKeyStatus.Name = "labelMarketAPIKeyStatus";
            this.labelMarketAPIKeyStatus.Size = new System.Drawing.Size(205, 26);
            this.labelMarketAPIKeyStatus.TabIndex = 14;
            this.labelMarketAPIKeyStatus.Text = "Refreshing...";
            this.labelMarketAPIKeyStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMarketAPIStatus
            // 
            this.labelMarketAPIStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelMarketAPIStatus.Location = new System.Drawing.Point(423, 58);
            this.labelMarketAPIStatus.Name = "labelMarketAPIStatus";
            this.labelMarketAPIStatus.Size = new System.Drawing.Size(205, 21);
            this.labelMarketAPIStatus.TabIndex = 15;
            this.labelMarketAPIStatus.Text = "Market API status:";
            this.labelMarketAPIStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AccountInfoPanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.labelMarketAPIStatus);
            this.Controls.Add(this.labelMarketAPIKeyStatus);
            this.Controls.Add(this.textBoxMarketAPIKey);
            this.Controls.Add(this.labelMarketAPIKey);
            this.Controls.Add(this.labelAccountSteamID64);
            this.Controls.Add(this.textBoxAccountSteamID64);
            this.Controls.Add(this.textBoxAccountTypeInProgram);
            this.Controls.Add(this.labelAccountTypeInProgram);
            this.Controls.Add(this.labelSteamAccountLogin);
            this.Controls.Add(this.textBoxSteamAccountLogin);
            this.Controls.Add(this.labelSteamAccountName);
            this.Controls.Add(this.pictureBoxSteamAccountAvatar);
            this.Controls.Add(this.textBoxSteamAccountName);
            this.Name = "AccountInfoPanelUserControl";
            this.Size = new System.Drawing.Size(640, 120);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteamAccountAvatar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSteamAccountName;
        private System.Windows.Forms.PictureBox pictureBoxSteamAccountAvatar;
        private System.Windows.Forms.Label labelSteamAccountName;
        private System.Windows.Forms.Label labelSteamAccountLogin;
        private System.Windows.Forms.TextBox textBoxSteamAccountLogin;
        private System.Windows.Forms.Label labelAccountTypeInProgram;
        private System.Windows.Forms.TextBox textBoxAccountTypeInProgram;
        private System.Windows.Forms.Label labelAccountSteamID64;
        private System.Windows.Forms.TextBox textBoxAccountSteamID64;
        private System.Windows.Forms.TextBox textBoxMarketAPIKey;
        private System.Windows.Forms.Label labelMarketAPIKey;
        private System.Windows.Forms.Label labelMarketAPIKeyStatus;
        private System.Windows.Forms.Label labelMarketAPIStatus;
    }
}
