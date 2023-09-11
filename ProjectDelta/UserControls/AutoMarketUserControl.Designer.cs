namespace ProjectDelta.UserControls
{
    partial class AutoMarketUserControl
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
            this.flowLayoutPanelAutoMarket = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAutoMarket
            // 
            this.flowLayoutPanelAutoMarket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelAutoMarket.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAutoMarket.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelAutoMarket.Name = "flowLayoutPanelAutoMarket";
            this.flowLayoutPanelAutoMarket.Size = new System.Drawing.Size(700, 650);
            this.flowLayoutPanelAutoMarket.TabIndex = 0;
            // 
            // AutoMarketUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelAutoMarket);
            this.Name = "AutoMarketUserControl";
            this.Size = new System.Drawing.Size(700, 650);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAutoMarket;
    }
}
