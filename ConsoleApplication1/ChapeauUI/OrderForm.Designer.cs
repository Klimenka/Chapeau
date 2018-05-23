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
            this.SuspendLayout();
            // 
            // ordersView
            // 
            this.ordersView.Location = new System.Drawing.Point(104, 69);
            this.ordersView.Name = "ordersView";
            this.ordersView.Size = new System.Drawing.Size(166, 47);
            this.ordersView.TabIndex = 0;
            this.ordersView.Text = "Orders view";
            this.ordersView.UseVisualStyleBackColor = true;
            // 
            // createNew
            // 
            this.createNew.Location = new System.Drawing.Point(519, 69);
            this.createNew.Name = "createNew";
            this.createNew.Size = new System.Drawing.Size(166, 47);
            this.createNew.TabIndex = 1;
            this.createNew.Text = "Create new";
            this.createNew.UseVisualStyleBackColor = true;
            // 
            // tablesViewBtn
            // 
            this.tablesViewBtn.Location = new System.Drawing.Point(917, 69);
            this.tablesViewBtn.Name = "tablesViewBtn";
            this.tablesViewBtn.Size = new System.Drawing.Size(166, 47);
            this.tablesViewBtn.TabIndex = 2;
            this.tablesViewBtn.Text = "Tables view";
            this.tablesViewBtn.UseVisualStyleBackColor = true;
            this.tablesViewBtn.Click += new System.EventHandler(this.TablesViewBtn_Click);
            // 
            // orderViewPanel
            // 
            this.orderViewPanel.Location = new System.Drawing.Point(49, 154);
            this.orderViewPanel.Name = "orderViewPanel";
            this.orderViewPanel.Size = new System.Drawing.Size(1110, 546);
            this.orderViewPanel.TabIndex = 3;
            // 
            // orderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 712);
            this.Controls.Add(this.orderViewPanel);
            this.Controls.Add(this.tablesViewBtn);
            this.Controls.Add(this.createNew);
            this.Controls.Add(this.ordersView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "orderForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Chapeau-Ordering";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ordersView;
        private System.Windows.Forms.Button createNew;
        private System.Windows.Forms.Button tablesViewBtn;
        private System.Windows.Forms.Panel orderViewPanel;
    }
}