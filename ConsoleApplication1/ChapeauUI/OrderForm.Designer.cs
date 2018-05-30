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
            this.createNew = new System.Windows.Forms.Button();
            this.tablesViewBtn = new System.Windows.Forms.Button();
            this.orderViewPanel = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.logoffLink = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.employeeID = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ordersView
            // 
            this.ordersView.Location = new System.Drawing.Point(102, 50);
            this.ordersView.Name = "ordersView";
            this.ordersView.Size = new System.Drawing.Size(148, 38);
            this.ordersView.TabIndex = 0;
            this.ordersView.Text = "Orders view";
            this.ordersView.UseVisualStyleBackColor = true;
            this.ordersView.Click += new System.EventHandler(this.ordersView_Click);
            // 
            // createNew
            // 
            this.createNew.Location = new System.Drawing.Point(526, 50);
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(148, 38);
            this.createNew.TabIndex = 1;
            this.createNew.Text = "Create new";
            this.createNew.UseVisualStyleBackColor = true;
            this.createNew.Click += new System.EventHandler(this.createNew_Click);
            // 
            // tablesViewBtn
            // 
            this.tablesViewBtn.Location = new System.Drawing.Point(921, 50);
            this.tablesViewBtn.Name = "tablesViewBtn";
            this.tablesViewBtn.Size = new System.Drawing.Size(148, 38);
            this.tablesViewBtn.TabIndex = 2;
            this.tablesViewBtn.Text = "Tables view";
            this.tablesViewBtn.UseVisualStyleBackColor = true;
            this.tablesViewBtn.Click += new System.EventHandler(this.TablesViewBtn_Click);
            // 
            // orderViewPanel
            // 
            this.orderViewPanel.Location = new System.Drawing.Point(0, 122);
            this.orderViewPanel.Name = "orderViewPanel";
            this.orderViewPanel.Size = new System.Drawing.Size(1218, 557);
            this.orderViewPanel.TabIndex = 3;
            this.orderViewPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.orderViewPanel_Paint);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logoffLink});
            this.statusStrip1.Location = new System.Drawing.Point(0, 545);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1083, 25);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // logoffLink
            // 
            this.logoffLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoffLink.Image = ((System.Drawing.Image)(resources.GetObject("logoffLink.Image")));
            this.logoffLink.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.logoffLink.IsLink = true;
            this.logoffLink.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.logoffLink.LinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Name = "logoffLink";
            this.logoffLink.Size = new System.Drawing.Size(74, 20);
            this.logoffLink.Text = "Log off";
            this.logoffLink.VisitedLinkColor = System.Drawing.Color.Maroon;
            this.logoffLink.Click += new System.EventHandler(this.logoffLink_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(955, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "EmployeeID";
            // 
            // employeeID
            // 
            this.employeeID.AutoSize = true;
            this.employeeID.Location = new System.Drawing.Point(1070, 19);
            this.employeeID.Name = "employeeID";
            this.employeeID.Size = new System.Drawing.Size(0, 17);
            this.employeeID.TabIndex = 5;
            this.employeeID.Click += new System.EventHandler(this.label2_Click);
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 570);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.orderViewPanel);
            this.Controls.Add(this.tablesViewBtn);
            this.Controls.Add(this.employeeID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.createNew);
            this.Controls.Add(this.ordersView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "orderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Chapeau-Ordering";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.orderForm_FormClosing);
            this.Load += new System.EventHandler(this.orderForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ordersView;
        private System.Windows.Forms.Button createNew;
        private System.Windows.Forms.Button tablesViewBtn;
        private System.Windows.Forms.Panel orderViewPanel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel logoffLink;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label employeeID;
    }
}