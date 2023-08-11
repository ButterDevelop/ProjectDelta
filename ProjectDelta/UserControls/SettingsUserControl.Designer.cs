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
            this.groupBoxMAFilesPath.SuspendLayout();
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
            // SettingsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.groupBoxMAFilesPath);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SettingsUserControl";
            this.Size = new System.Drawing.Size(700, 600);
            this.groupBoxMAFilesPath.ResumeLayout(false);
            this.groupBoxMAFilesPath.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMAFilesPath;
        private System.Windows.Forms.Label labelMAFilesPath;
        private System.Windows.Forms.GroupBox groupBoxMAFilesPath;
        private System.Windows.Forms.Button buttonMAFilesPath;
        private System.Windows.Forms.Button buttonSaveSettings;
    }
}
