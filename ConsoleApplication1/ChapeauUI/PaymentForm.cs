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
        public PaymentForm(/*Order order*/)
        {
            InitializeComponent();

            lbl_orderNr.Text = order.orderID.ToString();

        }

        private PaymentService paymentService = new PaymentService();

        private Payment payment = new Payment();

        

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (txtBox_tip.Text != "")
            {
                float tip = float.Parse(txtBox_tip.Text);
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

            Form bill = new Form();
            bill.Width = 300;
            bill.Height = 300;
            bill.Text = "Receipt";
            bill.ShowIcon = false;
            bill.StartPosition = FormStartPosition.CenterParent;

            ListView billListView = new ListView();

            billListView.Height = bill.Height;
            billListView.Width = bill.Width;
            billListView.View = View.Details;
            billListView.FullRowSelect = true;

            billListView.Columns.Add("Item Name", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("Amount", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("Price (inc.VAT)", -2, HorizontalAlignment.Left);
            billListView.Columns.Add("VAT", -2, HorizontalAlignment.Left);

             List<ChapeauModel.MenuItem> items = paymentService.menuItems(Convert.ToInt32(lbl_orderNr.Text));
            ListViewItem entryListItem = new ListViewItem();

            foreach (ChapeauModel.MenuItem item in items)
            {
                
                entryListItem = billListView.Items.Add(item.itemName.ToString());
                entryListItem.SubItems.Add(item.amount.ToString());
                entryListItem.SubItems.Add(item.price.ToString());
                entryListItem.SubItems.Add(item.vatPercentage.ToString());

            }

            

            bill.Controls.Add(billListView);
            bill.ShowDialog();



        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Payment canceled!");
        }
    }
}
