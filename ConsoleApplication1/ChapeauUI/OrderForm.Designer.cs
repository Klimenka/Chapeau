namespace ChapeauUI
{
    partial class orderForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(orderForm));
            this.ordersView = new System.Windows.Forms.Button();
            this.tablesViewBtn = new System.Windows.Forms.Button();
            this.orderViewPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.empNameLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.logoffLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordersView
            // 
            this.ordersView.Location = new System.Drawing.Point(44, 62);
            this.ordersView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ordersView.Name = "ordersView";
            this.ordersView.Size = new System.Drawing.Size(166, 48);
            this.ordersView.TabIndex = 2;
            this.ordersView.Text = "Need to be served";
            this.ordersView.UseVisualStyleBackColor = true;
            this.ordersView.Click += new System.EventHandler(this.ordersView_Click);
            // 
            // tablesViewBtn
            // 
            this.tablesViewBtn.Location = new System.Drawing.Point(975, 62);
            this.tablesViewBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tablesViewBtn.Name = "tablesViewBtn";
            this.tablesViewBtn.Size = new System.Drawing.Size(166, 48);
            this.tablesViewBtn.TabIndex = 0;
            this.tablesViewBtn.Text = "Tables view";
            this.tablesViewBtn.UseVisualStyleBackColor = true;
            this.tablesViewBtn.Click += new System.EventHandler(this.TablesViewBtn_Click);
            // 
            // orderViewPanel
            // 
            this.orderViewPanel.Location = new System.Drawing.Point(0, 131);
            this.orderViewPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.orderViewPanel.Name = "orderViewPanel";
            this.orderViewPanel.Size = new System.Drawing.Size(1218, 547);
            this.orderViewPanel.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empNameLbl,
            this.logoffLink});
            this.statusStrip1.Location = new System.Drawing.Point(0, 682);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1218, 30);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // empNameLbl
            // 
            this.empNameLbl.Image = ((System.Drawing.Image)(resources.GetObject("empNameLbl.Image")));
            this.empNameLbl.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.empNameLbl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.empNameLbl.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.empNameLbl.Name = "empNameLbl";
            this.empNameLbl.Size = new System.Drawing.Size(14, 25);
            // 
            // logoffLink
            // 
            this.logoffLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoffLink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logoffLink.IsLink = true;
            this.logoffLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.logoffLink.LinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Name = "logoffLink";
            this.logoffLink.Size = new System.Drawing.Size(65, 25);
            this.logoffLink.Text = "Log off";
            this.logoffLink.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Click += new System.EventHandler(this.logoffLink_Click);
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 712);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.orderViewPanel);
            this.Controls.Add(this.tablesViewBtn);
            this.Controls.Add(this.ordersView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "orderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Chapeau/ Ordering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.orderForm_FormClosing);
            this.Load += new System.EventHandler(this.TablesViewBtn_Click);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ordersView;
        private System.Windows.Forms.Button tablesViewBtn;
        private System.Windows.Forms.Panel orderViewPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel logoffLink;
        private System.Windows.Forms.ToolStripStatusLabel empNameLbl;
    }
}