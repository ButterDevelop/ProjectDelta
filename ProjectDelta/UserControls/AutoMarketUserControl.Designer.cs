﻿namespace ProjectDelta.UserControls
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
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelAutoMarket
            // 
            this.flowLayoutPanelAutoMarket.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelAutoMarket.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelAutoMarket.Location = new System.Drawing.Point(0, 100);
            this.flowLayoutPanelAutoMarket.Name = "flowLayoutPanelAutoMarket";
            this.flowLayoutPanelAutoMarket.Size = new System.Drawing.Size(700, 550);
            this.flowLayoutPanelAutoMarket.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "AAAAAAAAAAAAAA";
            // 
            // AutoMarketUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanelAutoMarket);
            this.Name = "AutoMarketUserControl";
            this.Size = new System.Drawing.Size(700, 650);
            this.Load += new System.EventHandler(this.AutoMarketUserControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelAutoMarket;
        private System.Windows.Forms.Label label1;
    }
}
