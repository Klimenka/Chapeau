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

            // show the name of the employee who logged in
            empNameLbl.Text = "[" + employeeName + " <" + employeePosition + ">" + "]";


            List<OrderItems> items = new List<OrderItems>();

            // BarMan will see Bar form & Chef will see Kitchen form
            if (employeePosition == Position.Barman)
            {
                items = orderItemService.GetBarItems();
            }

            else
            {
                items = orderItemService.GetKitchenItems();
            }


            // listview and editing its format 

            listView1.View = View.Details;
            listView1.FullRowSelect = true;
            listView1.CheckBoxes = true;
            listView1.MultiSelect = true;

            ColumnHeader headerOne = new ColumnHeader();
            ColumnHeader headerTwo = new ColumnHeader();
            ColumnHeader headerThree = new ColumnHeader();
            ColumnHeader headerFour = new ColumnHeader();
            ColumnHeader headerFive = new ColumnHeader();
            ColumnHeader headerSix = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerOne.Text = "OrderID";
            headerOne.TextAlign = HorizontalAlignment.Left;
            headerOne.Width = 150;

            headerTwo.TextAlign = HorizontalAlignment.Left;
            headerTwo.Text = "ItemID";
            headerTwo.Width = 145;

            headerThree.TextAlign = HorizontalAlignment.Left;
            headerThree.Text = "Name";
            headerThree.Width = 200;

            headerFour.TextAlign = HorizontalAlignment.Left;
            headerFour.Text = "Comment";
            headerFour.Width = 200;

            headerFive.TextAlign = HorizontalAlignment.Left;
            headerFive.Text = "Amount";
            headerFive.Width = 100;

            headerSix.TextAlign = HorizontalAlignment.Left;
            headerSix.Text = "Category";
            headerSix.Width = 150;

            // adding colums to the items list
            listView1.Columns.Add(headerOne);
            listView1.Columns.Add(headerTwo);
            listView1.Columns.Add(headerThree);
            listView1.Columns.Add(headerFour);
            listView1.Columns.Add(headerFive);
            listView1.Columns.Add(headerSix);



            int order_id_counter = items[0].orderID;

            // store data to the list view
            foreach (OrderItems item in items)
            {
                if (order_id_counter == item.orderID)
                {
                    ListViewItem entryListItem = listView1.Items.Add(item.orderID.ToString());
                    entryListItem.SubItems.Add(item.orderItemID.ToString());
                    entryListItem.SubItems.Add(item.itemName);
                    entryListItem.SubItems.Add(item.comment);
                    entryListItem.SubItems.Add(item.amount.ToString());
                    entryListItem.SubItems.Add(item.category.ToString());


                }

                else
                {

                    //listView1.check = false;

                    //Empty line(Space) between orders
                    ListViewItem entryListItem = listView1.Items.Add("");
                    //listView1.CheckBoxes = true;
                    entryListItem = listView1.Items.Add(item.orderID.ToString());
                    entryListItem.SubItems.Add(item.orderItemID.ToString());
                    entryListItem.SubItems.Add(item.itemName);
                    entryListItem.SubItems.Add(item.comment);
                    entryListItem.SubItems.Add(item.amount.ToString());
                    entryListItem.SubItems.Add(item.category.ToString());

                    order_id_counter = item.orderID;
                }


            }

            ready_btn.Click += (s, ee) =>
            {
                //if the list of items is empty, show warning message
                if (listView1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select something");
                    return;
                }

                //save checked ItemsID
                int[] checkedItems = new int[listView1.CheckedItems.Count];
                for (int i = 0; i < listView1.CheckedItems.Count; i++)
                {
                    checkedItems[i] = int.Parse(listView1.CheckedItems[i].SubItems[0].Text.ToString());
                }

                //send to DB items for the update
                orderItemService.CheckAsServed(checkedItems);


                //kitchenForm.Show();


            };
        
        }
        
        // to add the line between the orders
        //private void listView1_DrawItem(object sender, DrawListViewItemEventArgs e)
        //{
        //    e.DrawDefault = true;

        //    if (e.Item.Text == "2")
        //    {
        //        e.Graphics.DrawLine(Pens.Black, e.Bounds.Left, e.Bounds.Bottom, e.Bounds.Right, e.Bounds.Bottom);
        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    ListView showOrderItems = new ListView();
        //    showOrderItems = ShowOrderItems(int.Parse(employeeID.Text));
        //    listView1.Controls.Add(showOrderItems);

        //    Button ready = new Button();
        //    ready.Text = "SERVED";
        //    //ready.Width = 166;
        //    //ready.Height = 50;
            
        //    listView1.Controls.Add(ready);

        

        //}

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

     

        private void KitchenBarForm_Load(object sender, EventArgs e)
        {
         
        }
    }
}
