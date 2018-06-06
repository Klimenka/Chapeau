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
        List<OrderItems> items = new List<OrderItems>();
        Position position = new Position();
       

        public KitchenBarForm(Employess employee)
        {
            InitializeComponent();

            // show the name of the employee who logged in
            empNameLbl.Text = "[" + employee.EmployeeName + " <" + (Position)employee.positionID + ">" + "]";
            

            position = (Position)employee.positionID;

            Timer timer = new Timer();

            timer.Interval = 10000;

            timer.Enabled = true;

            timer.Tick += new System.EventHandler(OnTimerEvent);
        }

        private void OnTimerEvent(object sender, EventArgs e)

        {
            KitchenBarForm_Load(sender, e);

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



        private void KitchenBarForm_Load(object sender, EventArgs e)
        {
            ListViewKitchenBar.Clear();

            int counter1 = 0;
            int counter2 = 0;
            bool flag = false;

            // BarMan will see Bar form & Chef will see Kitchen form
            if (position == Position.Barman)
            {
                items = orderItemService.GetBarItems();
            }

            else
            {
                items = orderItemService.GetKitchenItems();
            }

            ListViewKitchenBar.View = View.Details;
            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();


            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 120;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 400;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Amount";
            headerThird.Width = 100;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Category";
            headerFourth.Width = 150;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Comments";
            headerFifth.Width = 150;


            // adding colums to the list
            ListViewKitchenBar.Columns.Add(headerFirst);
            ListViewKitchenBar.Columns.Add(headerSecond);
            ListViewKitchenBar.Columns.Add(headerThird);
            ListViewKitchenBar.Columns.Add(headerFourth);
            ListViewKitchenBar.Columns.Add(headerFifth);



            foreach (OrderItems item in items)
            {
                    if (counter1 == 0 || (counter1 != item.orderID && counter2 != item.orderID && flag == true))
                    {
                        counter1 = item.orderID;
                        flag = false;
                    }


                    if (counter1 == item.orderID)
                    {
                        ListViewItem entryListItem = ListViewKitchenBar.Items.Add(item.orderItemID.ToString());
                        entryListItem.BackColor = Color.LightBlue;
                        entryListItem.SubItems.Add(item.itemName);
                        entryListItem.SubItems.Add(item.amount.ToString());
                        entryListItem.SubItems.Add(item.category.ToString());
                        entryListItem.SubItems.Add(item.comment);

                }
                    else
                    {
                        counter2 = item.orderID;
                        flag = true;
                        ListViewItem entryListItem = ListViewKitchenBar.Items.Add(item.orderItemID.ToString());
                        entryListItem.BackColor = Color.LightYellow;
                        entryListItem.SubItems.Add(item.itemName);
                        entryListItem.SubItems.Add(item.amount.ToString());
                        entryListItem.SubItems.Add(item.category.ToString());
                        entryListItem.SubItems.Add(item.comment);
                }
               
              
            }

           
        }

        private void isReady_btn_Click(object sender, EventArgs e)
        {

            //save checked ItemsIDs
            int[] checkedItems = new int[ListViewKitchenBar.CheckedItems.Count];
            for (int i = 0; i < ListViewKitchenBar.CheckedItems.Count; i++)
            {
                checkedItems[i] = int.Parse(ListViewKitchenBar.CheckedItems[i].SubItems[0].Text.ToString());
            }

            //send to DB items for the update
            orderItemService.CheckAsReady(checkedItems);


            KitchenBarForm_Load(sender, e);
        }
    }
}
