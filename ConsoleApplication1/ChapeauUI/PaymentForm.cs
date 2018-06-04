using System;
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
        public PaymentForm(Order order, float total)
        {
            InitializeComponent();

            lbl_total.Text = total.ToString("0.00") + " euro";
            lbl_orderNr.Text = order.orderID.ToString();
            employeeID = order.employeeID;
            tableID = order.tableID;
        }

        private PaymentService paymentService = new PaymentService();
        private Payment payment = new Payment();
        private float tip;



        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txtBox_tip.Text != "")
            {
                tip = float.Parse(txtBox_tip.Text);
                lblTip.Text = tip.ToString();
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
            float totalPrice=0;

            foreach (ChapeauModel.MenuItem item in items)
            {

                entryListItem = billListView.Items.Add(item.itemName);
                entryListItem.SubItems.Add(item.amount.ToString());
                entryListItem.SubItems.Add(item.price.ToString("0.00"));
                entryListItem.SubItems.Add(item.vatPercentage.ToString("0.00"));

                totalPrice += item.totalPrice;

            }
            
            Label lblTotalPrice = new Label();
            lblTotalPrice.Text = "Total price:";
            lblTotalPrice.Location = new Point(0, billListView.Bottom + 10);

            Label lblTotalPriceShow = new Label();
            lblTotalPriceShow.Text = totalPrice.ToString("0.00");
            lblTotalPriceShow.Location = new Point(250, billListView.Bottom + 10);

            Label lblPayMethod = new Label();
            lblPayMethod.Text = "Payment Method:";
            lblPayMethod.Location = new Point(0, billListView.Bottom + 40);


            Label lblPayMethodShow = new Label();
            lblPayMethodShow.Text = payment.paymentMethod.ToString();
            lblPayMethodShow.Location = new Point(250, billListView.Bottom + 40);

            Label lblTip = new Label();
            lblTip.Text = "Tip:";
            lblTip.Location = new Point(0, billListView.Bottom + 70);

            Label lblTipShow = new Label();
            lblTipShow.Text = tip.ToString("0.00");
            lblTipShow.Location = new Point(250, billListView.Bottom + 70);

            Label lblFeedback = new Label();
            lblFeedback.Text = "Comment:";
            lblFeedback.Location = new Point(0, billListView.Bottom + 100);

            Label lblFeedbackShow = new Label();
            lblFeedbackShow.Text = payment.feedback;
            lblFeedbackShow.Location = new Point(250, billListView.Bottom + 100);


            bill.Controls.Add(billListView);
            bill.Controls.Add(lblTotalPriceShow);
            bill.Controls.Add(lblTotalPrice);
            bill.Controls.Add(lblPayMethod);
            bill.Controls.Add(lblPayMethodShow);
            bill.Controls.Add(lblTip);
            bill.Controls.Add(lblTipShow);
            bill.Controls.Add(lblFeedback);
            bill.Controls.Add(lblFeedbackShow);

            bill.ShowDialog();

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment canceled!");
            this.Close();
        }
    }
}
