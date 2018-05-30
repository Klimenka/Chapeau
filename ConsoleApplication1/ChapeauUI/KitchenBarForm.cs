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
    public partial class KitchenBarForm : Form
    {
        OrderItemsService orderItemService = new OrderItemsService();

        public KitchenBarForm(string employeeName, Position employeePosition)
        {
            InitializeComponent();

            // show the name of the user who logged in
            empNameLbl.Text = "[" + employeeName + " <" + employeePosition + ">" + "]";
            List<OrderItems> items = new List<OrderItems>();


            if (employeePosition == Position.Barman)
            {
                items = orderItemService.GetBarItems();
            }

            else
            {
                items = orderItemService.GetKitchenItems();
            }


        

            // a list and editing its format 
            
            listView1.Height = 250;
            listView1.Width = 500;
            listView1.Left = 30;
            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.MultiSelect = true;

            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();
            ColumnHeader headerSixth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "OrderID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 75;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "ItemID";
            headerSecond.Width = 45;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Name";
            headerThird.Width = 150;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Comment";
            headerFourth.Width = 70;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Amount";
            headerFifth.Width = 150;

            headerSixth.TextAlign = HorizontalAlignment.Left;
            headerSixth.Text = "Category";
            headerSixth.Width = 150;

            // adding colums to the list
            listView1.Columns.Add(headerFirst);
            listView1.Columns.Add(headerSecond);
            listView1.Columns.Add(headerThird);
            listView1.Columns.Add(headerFourth);
            listView1.Columns.Add(headerFifth);

            // store data to the list view
            foreach (OrderItems item in items)
            {
                ListViewItem entryListItem = listView1.Items.Add(item.orderID.ToString());
                entryListItem.SubItems.Add(item.orderItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.comment);
                entryListItem.SubItems.Add(item.amount.ToString());
                entryListItem.SubItems.Add(item.category.ToString());

            }




        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }
        
        
      

        // log off link
        private void logoffLink_Click(object sender, EventArgs e)
        {
            // to show a confirmation message
            if (MessageBox.Show("Are you sure you want to log off?", "Logging off",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void KitchenBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

    }
}
