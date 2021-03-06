﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauModel;
using ChapeauLogic;

namespace ChapeauUI
{
    public partial class PaymentForm : Form
    {

        private int employeeID;
        private int tableID;
        private Form orderForm;

        public PaymentForm(Order order, float total, Form form)
        {
            InitializeComponent();

            lbl_total.Text = total.ToString("0.00") + " euro";
            lbl_orderNr.Text = order.orderID.ToString();
            employeeID = order.employeeID;
            tableID = order.tableID;
            orderForm = form;
        }


        private PaymentService paymentService = new PaymentService();
        private Payment payment = new Payment();
        private float tip;



        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txtBox_tip.Text != "")
            {
                tip = float.Parse(txtBox_tip.Text);
                lblTip.Text = tip.ToString() + " euro";
            }
            else
            {
                lblTip.Text = "0";
            }

        }

        private void btn_payNow_Click(object sender, EventArgs e)
        {
            if (rb_cash.Checked)
            {
                payment.paymentMethod = PaymentMethod.Cash;
            }
            else if (rb_cc.Checked)
            {
                payment.paymentMethod = PaymentMethod.CreditCard;
            }
            else
            {
                payment.paymentMethod = PaymentMethod.Pin;
            }

            payment.orderID = Convert.ToInt32(lbl_orderNr.Text);
            payment.employeeID = employeeID;
            payment.tip = tip;
            payment.feedback = txtBoxFeedback.Text;
            paymentService.StorePayment(payment, tableID);

            ShowBill();

        }

        private void ShowBill()
        {
            Form bill = new Form();
            bill.Width = 350;
            bill.Height = 350;
            bill.Text = "Receipt";
            bill.ShowIcon = false;
            bill.AutoSize = true;
            bill.StartPosition = FormStartPosition.CenterParent;

            ListView billListView = new ListView();

            billListView.Height = bill.Height - 50;
            billListView.Width = bill.Width;
            billListView.AutoSize = true;
            billListView.View = View.Details;
            billListView.FullRowSelect = true;

            billListView.Columns.Add("Item Name", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("Amount", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("Price (inc.VAT)", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("VAT", -2, HorizontalAlignment.Left);

            List<ChapeauModel.MenuItem> items = paymentService.menuItems(Convert.ToInt32(lbl_orderNr.Text));
            ListViewItem entryListItem = new ListViewItem();
            float totalPrice = 0;

            foreach (ChapeauModel.MenuItem item in items)
            {

                entryListItem = billListView.Items.Add(item.itemName);
                entryListItem.SubItems.Add(item.item.amount.ToString());
                entryListItem.SubItems.Add(item.price.ToString("0.00"));
                entryListItem.SubItems.Add(item.vatPercentage.ToString("0.00"));

                totalPrice += item.totalPrice;

            }

            Label lblTip = new Label();
            lblTip.Text = "Tip:";
            lblTip.Location = new Point(0, billListView.Bottom + 10);

            Label lblTipShow = new Label();
            lblTipShow.Text = tip.ToString("0.00" + " euro");
            lblTipShow.Location = new Point(250, billListView.Bottom + 10);

            Label lblTotalPrice = new Label();
            lblTotalPrice.Text = "Total Price:";
            lblTotalPrice.Location = new Point(0, billListView.Bottom + 40);

            Label lblTotalPriceShow = new Label();
            lblTotalPriceShow.Text = (tip + totalPrice).ToString("0.00" + " euro");
            lblTotalPriceShow.Location = new Point(250, billListView.Bottom + 40);

            Label lblPayMethod = new Label();
            lblPayMethod.Text = "Payment Method:";
            lblPayMethod.Location = new Point(0, billListView.Bottom + 70);


            Label lblPayMethodShow = new Label();
            lblPayMethodShow.Text = payment.paymentMethod.ToString();
            lblPayMethodShow.Location = new Point(250, billListView.Bottom + 70);

            Label lblFeedback = new Label();
            lblFeedback.Text = "Comment:";
            lblFeedback.Location = new Point(0, billListView.Bottom + 100);

            Label lblFeedbackShow = new Label();
            lblFeedbackShow.Text = payment.feedback;
            lblFeedbackShow.AutoSize = true;
            lblFeedbackShow.TextAlign = ContentAlignment.TopLeft;
            lblFeedbackShow.MaximumSize = new Size(100, 0);

            lblFeedbackShow.Location = new Point(250, billListView.Bottom + 100);

            Button buttoclose_btn = new Button();
            buttoclose_btn.Text = "Close";
            buttoclose_btn.BackColor = Color.Red;
            buttoclose_btn.Location = new Point(250, billListView.Bottom + 150);
            buttoclose_btn.Width = 100;
            buttoclose_btn.Height = 50;
            buttoclose_btn.Click += new EventHandler(this.buttoclose_btn_Click);


            bill.Controls.Add(billListView);
            bill.Controls.Add(lblTotalPriceShow);
            bill.Controls.Add(lblTotalPrice);
            bill.Controls.Add(lblPayMethod);
            bill.Controls.Add(lblPayMethodShow);
            bill.Controls.Add(lblTip);
            bill.Controls.Add(lblTipShow);
            bill.Controls.Add(lblFeedback);
            bill.Controls.Add(lblFeedbackShow);
            bill.Controls.Add(buttoclose_btn);

            bill.ShowDialog();


        }
        private void buttoclose_btn_Click(object sender, EventArgs e)
        {
            orderForm.Activate();
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment canceled!");
            this.Close();
        }
    }
}
