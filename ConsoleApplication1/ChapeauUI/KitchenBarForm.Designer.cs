namespace ChapeauUI
{
    partial class KitchenBarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KitchenBarForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.empNameLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.logoffLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.ListViewKitchenBar = new System.Windows.Forms.ListView();
            this.isReady_btn = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.empNameLbl,
            this.logoffLink});
            this.statusStrip1.Location = new System.Drawing.Point(0, 794);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 11, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1687, 25);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // empNameLbl
            // 
            this.empNameLbl.Image = ((System.Drawing.Image)(resources.GetObject("empNameLbl.Image")));
            this.empNameLbl.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.empNameLbl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.empNameLbl.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.empNameLbl.Name = "empNameLbl";
            this.empNameLbl.Size = new System.Drawing.Size(14, 20);
            // 
            // logoffLink
            // 
            this.logoffLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoffLink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logoffLink.IsLink = true;
            this.logoffLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.logoffLink.LinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Name = "logoffLink";
            this.logoffLink.Size = new System.Drawing.Size(52, 20);
            this.logoffLink.Text = "Log off";
            this.logoffLink.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Click += new System.EventHandler(this.logoffLink_Click);
            // 
            // ListViewKitchenBar
            // 
            this.ListViewKitchenBar.CheckBoxes = true;
            this.ListViewKitchenBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ListViewKitchenBar.FullRowSelect = true;
            this.ListViewKitchenBar.Location = new System.Drawing.Point(218, 58);
            this.ListViewKitchenBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ListViewKitchenBar.Name = "ListViewKitchenBar";
            this.ListViewKitchenBar.Size = new System.Drawing.Size(1271, 562);
            this.ListViewKitchenBar.TabIndex = 12;
            this.ListViewKitchenBar.UseCompatibleStateImageBehavior = false;
            // 
            // isReady_btn
            // 
            this.isReady_btn.BackColor = System.Drawing.Color.Green;
            this.isReady_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.isReady_btn.ForeColor = System.Drawing.Color.White;
            this.isReady_btn.Location = new System.Drawing.Point(692, 670);
            this.isReady_btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.isReady_btn.Name = "isReady_btn";
            this.isReady_btn.Size = new System.Drawing.Size(323, 83);
            this.isReady_btn.TabIndex = 13;
            this.isReady_btn.Text = "READY";
            this.isReady_btn.UseVisualStyleBackColor = false;
            this.isReady_btn.Click += new System.EventHandler(this.isReady_btn_Click);
            // 
            // KitchenBarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1687, 819);
            this.Controls.Add(this.isReady_btn);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ListViewKitchenBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "KitchenBarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Chapeau-Kitchen/Bar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KitchenBarForm_FormClosing);
            this.Load += new System.EventHandler(this.KitchenBarForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel empNameLbl;
        private System.Windows.Forms.ToolStripStatusLabel logoffLink;
        private System.Windows.Forms.ListView ListViewKitchenBar;
        private System.Windows.Forms.Button isReady_btn;
    }
}