namespace ProjectDelta.UserControls
{
    partial class AllAccountsInfoUserControl
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
            this.vScrollBarAccounts = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelAccounts = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // vScrollBarAccounts
            // 
            this.vScrollBarAccounts.Location = new System.Drawing.Point(674, 100);
            this.vScrollBarAccounts.Name = "vScrollBarAccounts";
            this.vScrollBarAccounts.Size = new System.Drawing.Size(26, 550);
            this.vScrollBarAccounts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "BBBBBBBBBBBBBBBBBBBBB";
            // 
            // flowLayoutPanelAccounts
            // 
            this.flowLayoutPanelAccounts.AutoScroll = true;
            this.flowLayoutPanelAccounts.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanelAccounts.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAccounts.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelAccounts.Name = "flowLayoutPanelAccounts";
            this.flowLayoutPanelAccounts.Size = new System.Drawing.Size(700, 550);
            this.flowLayoutPanelAccounts.TabIndex = 0;
            this.flowLayoutPanelAccounts.Visible = false;
            // 
            // AllAccountsInfoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.vScrollBarAccounts);
            this.Controls.Add(this.flowLayoutPanelAccounts);
            this.Name = "AllAccountsInfoUserControl";
            this.Size = new System.Drawing.Size(700, 650);
            this.Load += new System.EventHandler(this.AllAccountsInfoUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.VScrollBar vScrollBarAccounts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAccounts;
    }
}
