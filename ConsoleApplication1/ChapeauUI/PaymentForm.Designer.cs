namespace ChapeauUI
{
    partial class PaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaymentForm));
            this.Order = new System.Windows.Forms.Label();
            this.lbl_orderNr = new System.Windows.Forms.Label();
            this.total = new System.Windows.Forms.Label();
            this.totalWithTip = new System.Windows.Forms.Label();
            this.paymentMethod = new System.Windows.Forms.Label();
            this.lbl_tip = new System.Windows.Forms.Label();
            this.lbl_comments = new System.Windows.Forms.Label();
            this.lbl_total = new System.Windows.Forms.Label();
            this.lblTip = new System.Windows.Forms.Label();
            this.rb_cash = new System.Windows.Forms.RadioButton();
            this.rb_pin = new System.Windows.Forms.RadioButton();
            this.rb_cc = new System.Windows.Forms.RadioButton();
            this.visa = new System.Windows.Forms.PictureBox();
            this.amex = new System.Windows.Forms.PictureBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_payNow = new System.Windows.Forms.Button();
            this.txtBox_tip = new System.Windows.Forms.TextBox();
            this.btn_add = new System.Windows.Forms.Button();
            this.txtBoxFeedback = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.visa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.amex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Order
            // 
            this.Order.AutoSize = true;
            this.Order.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Order.Location = new System.Drawing.Point(57, 50);
            this.Order.Name = "Order";
            this.Order.Size = new System.Drawing.Size(54, 20);
            this.Order.TabIndex = 0;
            this.Order.Text = "Order";
            // 
            // lbl_orderNr
            // 
            this.lbl_orderNr.AutoSize = true;
            this.lbl_orderNr.Location = new System.Drawing.Point(286, 50);
            this.lbl_orderNr.Name = "lbl_orderNr";
            this.lbl_orderNr.Size = new System.Drawing.Size(0, 20);
            this.lbl_orderNr.TabIndex = 1;
            // 
            // total
            // 
            this.total.AutoSize = true;
            this.total.Location = new System.Drawing.Point(57, 105);
            this.total.Name = "total";
            this.total.Size = new System.Drawing.Size(116, 20);
            this.total.TabIndex = 4;
            this.total.Text = "Total (incl VAT)";
            // 
            // totalWithTip
            // 
            this.totalWithTip.AutoSize = true;
            this.totalWithTip.Location = new System.Drawing.Point(57, 161);
            this.totalWithTip.Name = "totalWithTip";
            this.totalWithTip.Size = new System.Drawing.Size(30, 20);
            this.totalWithTip.TabIndex = 5;
            this.totalWithTip.Text = "Tip";
            // 
            // paymentMethod
            // 
            this.paymentMethod.AutoSize = true;
            this.paymentMethod.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.paymentMethod.Location = new System.Drawing.Point(57, 238);
            this.paymentMethod.Name = "paymentMethod";
            this.paymentMethod.Size = new System.Drawing.Size(247, 20);
            this.paymentMethod.TabIndex = 6;
            this.paymentMethod.Text = "Choose your payment method";
            // 
            // lbl_tip
            // 
            this.lbl_tip.AutoSize = true;
            this.lbl_tip.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_tip.Location = new System.Drawing.Point(902, 50);
            this.lbl_tip.Name = "lbl_tip";
            this.lbl_tip.Size = new System.Drawing.Size(33, 20);
            this.lbl_tip.TabIndex = 7;
            this.lbl_tip.Text = "Tip";
            // 
            // lbl_comments
            // 
            this.lbl_comments.AutoSize = true;
            this.lbl_comments.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_comments.Location = new System.Drawing.Point(902, 332);
            this.lbl_comments.Name = "lbl_comments";
            this.lbl_comments.Size = new System.Drawing.Size(94, 20);
            this.lbl_comments.TabIndex = 8;
            this.lbl_comments.Text = "Comments";
            // 
            // lbl_total
            // 
            this.lbl_total.AutoSize = true;
            this.lbl_total.Location = new System.Drawing.Point(286, 105);
            this.lbl_total.Name = "lbl_total";
            this.lbl_total.Size = new System.Drawing.Size(18, 20);
            this.lbl_total.TabIndex = 12;
            this.lbl_total.Text = "0";
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(286, 161);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(18, 20);
            this.lblTip.TabIndex = 13;
            this.lblTip.Text = "0";
            // 
            // rb_cash
            // 
            this.rb_cash.AutoSize = true;
            this.rb_cash.Location = new System.Drawing.Point(61, 299);
            this.rb_cash.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_cash.Name = "rb_cash";
            this.rb_cash.Size = new System.Drawing.Size(71, 24);
            this.rb_cash.TabIndex = 14;
            this.rb_cash.TabStop = true;
            this.rb_cash.Text = "Cash";
            this.rb_cash.UseVisualStyleBackColor = true;
            // 
            // rb_pin
            // 
            this.rb_pin.AutoSize = true;
            this.rb_pin.Location = new System.Drawing.Point(61, 351);
            this.rb_pin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_pin.Name = "rb_pin";
            this.rb_pin.Size = new System.Drawing.Size(56, 24);
            this.rb_pin.TabIndex = 15;
            this.rb_pin.TabStop = true;
            this.rb_pin.Text = "Pin";
            this.rb_pin.UseVisualStyleBackColor = true;
            // 
            // rb_cc
            // 
            this.rb_cc.AutoSize = true;
            this.rb_cc.Location = new System.Drawing.Point(61, 464);
            this.rb_cc.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rb_cc.Name = "rb_cc";
            this.rb_cc.Size = new System.Drawing.Size(114, 24);
            this.rb_cc.TabIndex = 16;
            this.rb_cc.TabStop = true;
            this.rb_cc.Text = "Credit Card";
            this.rb_cc.UseVisualStyleBackColor = true;
            // 
            // visa
            // 
            this.visa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.visa.Image = ((System.Drawing.Image)(resources.GetObject("visa.Image")));
            this.visa.InitialImage = ((System.Drawing.Image)(resources.GetObject("visa.InitialImage")));
            this.visa.Location = new System.Drawing.Point(87, 509);
            this.visa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.visa.Name = "visa";
            this.visa.Size = new System.Drawing.Size(69, 51);
            this.visa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.visa.TabIndex = 17;
            this.visa.TabStop = false;
            // 
            // amex
            // 
            this.amex.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.amex.Image = ((System.Drawing.Image)(resources.GetObject("amex.Image")));
            this.amex.InitialImage = ((System.Drawing.Image)(resources.GetObject("amex.InitialImage")));
            this.amex.Location = new System.Drawing.Point(162, 509);
            this.amex.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.amex.Name = "amex";
            this.amex.Size = new System.Drawing.Size(69, 51);
            this.amex.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.amex.TabIndex = 18;
            this.amex.TabStop = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.Red;
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(61, 612);
            this.btn_cancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(170, 59);
            this.btn_cancel.TabIndex = 24;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_payNow
            // 
            this.btn_payNow.BackColor = System.Drawing.Color.Green;
            this.btn_payNow.ForeColor = System.Drawing.Color.White;
            this.btn_payNow.Location = new System.Drawing.Point(964, 612);
            this.btn_payNow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_payNow.Name = "btn_payNow";
            this.btn_payNow.Size = new System.Drawing.Size(170, 59);
            this.btn_payNow.TabIndex = 25;
            this.btn_payNow.Text = "Pay Now";
            this.btn_payNow.UseVisualStyleBackColor = false;
            this.btn_payNow.Click += new System.EventHandler(this.btn_payNow_Click);
            // 
            // txtBox_tip
            // 
            this.txtBox_tip.ForeColor = System.Drawing.Color.Black;
            this.txtBox_tip.Location = new System.Drawing.Point(964, 50);
            this.txtBox_tip.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBox_tip.Name = "txtBox_tip";
            this.txtBox_tip.Size = new System.Drawing.Size(169, 26);
            this.txtBox_tip.TabIndex = 26;
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(964, 95);
            this.btn_add.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(84, 41);
            this.btn_add.TabIndex = 27;
            this.btn_add.Text = "Add";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // txtBoxFeedback
            // 
            this.txtBoxFeedback.ForeColor = System.Drawing.Color.Black;
            this.txtBoxFeedback.Location = new System.Drawing.Point(906, 385);
            this.txtBoxFeedback.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtBoxFeedback.Multiline = true;
            this.txtBoxFeedback.Name = "txtBoxFeedback";
            this.txtBoxFeedback.Size = new System.Drawing.Size(228, 174);
            this.txtBoxFeedback.TabIndex = 28;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(87, 385);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(69, 51);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // PaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1218, 712);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtBoxFeedback);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.txtBox_tip);
            this.Controls.Add(this.btn_payNow);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.amex);
            this.Controls.Add(this.visa);
            this.Controls.Add(this.rb_cc);
            this.Controls.Add(this.rb_pin);
            this.Controls.Add(this.rb_cash);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.lbl_total);
            this.Controls.Add(this.lbl_comments);
            this.Controls.Add(this.lbl_tip);
            this.Controls.Add(this.paymentMethod);
            this.Controls.Add(this.totalWithTip);
            this.Controls.Add(this.total);
            this.Controls.Add(this.lbl_orderNr);
            this.Controls.Add(this.Order);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "PaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restaurant Chapeau/ Payment";
            ((System.ComponentModel.ISupportInitialize)(this.visa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.amex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Order;
        private System.Windows.Forms.Label lbl_orderNr;
        private System.Windows.Forms.Label total;
        private System.Windows.Forms.Label totalWithTip;
        private System.Windows.Forms.Label paymentMethod;
        private System.Windows.Forms.Label lbl_tip;
        private System.Windows.Forms.Label lbl_comments;
        private System.Windows.Forms.Label lbl_total;
        private System.Windows.Forms.Label lblTip;
        private System.Windows.Forms.RadioButton rb_cash;
        private System.Windows.Forms.RadioButton rb_pin;
        private System.Windows.Forms.RadioButton rb_cc;
        private System.Windows.Forms.PictureBox visa;
        private System.Windows.Forms.PictureBox amex;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_payNow;
        private System.Windows.Forms.TextBox txtBox_tip;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.TextBox txtBoxFeedback;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}