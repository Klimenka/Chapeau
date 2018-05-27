using ChapeauModel;
using ChapeauLogic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ChapeauLogic;
using ChapeauModel;
using LogicLayer;


namespace ChapeauUI
{
    public partial class orderForm : Form
    {
        OrderItemsService orderItemService = new OrderItemsService();
        OrderService orderService = new OrderService();
        MenuItemService menuItemService = new MenuItemService();
        TableService tableService = new TableService();
        List<OrderItems> orderItemsList = new List<OrderItems>();
        DateTime time = new DateTime();


        public orderForm(int ID)
        {
            InitializeComponent();
            Shown += orderForm_Load;

            //save the employee ID on the form
            employeeID.Text = ID.ToString();
        }

        private void orderForm_Load(object sender, EventArgs e)

        {

            createNew.Enabled = true;
            orderViewPanel.Controls.Clear();

            ListView showOrderItems = new ListView();
            showOrderItems = orderItemService.ShowOrderItems(int.Parse(employeeID.Text));
            orderViewPanel.Controls.Add(showOrderItems);
            

            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(550, 45);
            orderViewPanel.Controls.Add(table);

            ComboBox table_choice = new ComboBox();
            table_choice.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            table.AutoSize = true;
            table_choice.Location = new Point(600, 45);
            orderViewPanel.Controls.Add(table_choice);

            Label find_order = new Label();
            find_order.Text = "Find the order by table number: ";
            find_order.AutoSize = true;
            find_order.Location = new Point(550, 20);
            orderViewPanel.Controls.Add(find_order);

            Button find_order_by_table = new Button();
            find_order_by_table.Text = "Open the order";
            find_order_by_table.Width = 166;
            find_order_by_table.Height = 47;
            find_order_by_table.Location = new Point(550, 75);
            orderViewPanel.Controls.Add(find_order_by_table);

            find_order_by_table.Click += (s, ee) =>
            {

                if (table_choice.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a table");
                    return;
                }

                OrderItems existedOrder = new OrderItems();
                existedOrder.tableID = int.Parse(table_choice.SelectedItem.ToString());
 
                ShowExistedOrder(existedOrder);


            };

            Button served = new Button();
            served.Text = "Served";
            served.Width = 166;
            served.Height = 47;
            served.Location = new Point(285, 265);
            orderViewPanel.Controls.Add(served);

            served.Click += (s, ee) =>
            {
                //if the list of items is empty, show warning message
                if (showOrderItems.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select items to be served");
                    return;
                }

                //save checked ItemsID
                int[] checkedItems = new int[showOrderItems.CheckedItems.Count];
                for (int i = 0; i < showOrderItems.CheckedItems.Count; i++)
                {
                    checkedItems[i] = int.Parse(showOrderItems.CheckedItems[i].SubItems[0].Text.ToString());
                }

                //send to DB items for the update
                orderItemService.CheckAsServed(checkedItems);


                orderForm_Load(s, ee);


            };

            
        }

        

        //Show an existed order
        private void ShowExistedOrder(Order existedOrder)
        {
            createNew.Enabled = false;
            orderViewPanel.Controls.Clear();

            existedOrder.orderID = orderService.GetOrderID(existedOrder.tableID);

            ListView existedOrderListControl = new ListView();
            existedOrderListControl = orderItemService.ShowOrderItemsExisted(existedOrder);
            orderViewPanel.Controls.Add(existedOrderListControl);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 47;
            add_btn.Location = new Point(00, 265);
           // add_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(add_btn);

            Button payment_btn = new Button();
            payment_btn.Text = "PAYMENT";
            payment_btn.Width = 166;
            payment_btn.Height = 47;
            payment_btn.Location = new Point(550, 265);
            payment_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(payment_btn);

            payment_btn.Click += (s, ee) =>
            {
                //don't know what check here
                //if (orderItemsList.Count == 0)
                //{
                //    MessageBox.Show("Please select an item for a new order");
                //    return;
                //}

                //show payment form
                PaymentForm paymentForm = new PaymentForm(existedOrder);
                paymentForm.Show();
            };

            add_btn.Click += (s, ee) =>
            {
                ShowMenuItemInterface(existedOrder);

            };


        }


        //new order button click
        private void createNew_Click(object sender, EventArgs e)
        {
            createNew.Enabled = false;
            //clear List for new order after confirmation button click
            orderItemsList.Clear();

            //creating of a new order in DB
            string table_text = ShowChooseTable();
            int tableID;
            tableID = int.Parse(table_text);
            Order order = new Order();
            order = orderService.NewOrder(int.Parse(employeeID.Text), tableID);

            ShowMenuItemInterface(order);
            //clear space for new data
        }

        public void ShowMenuItemInterface(Order order)
        {
            createNew.Enabled = false;
            orderViewPanel.Controls.Clear();

            //saving data on the panel (creation of the buttons and labels)
            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(560, 240);
            orderViewPanel.Controls.Add(table);

            Label chosen_table = new Label();
            chosen_table.Text = order.tableID.ToString();
            chosen_table.AutoSize = true;
            chosen_table.Location = new Point(620, 240);
            orderViewPanel.Controls.Add(chosen_table);

            Label order_text = new Label();
            order_text.Text = "Order: ";
            order_text.AutoSize = true;
            order_text.Location = new Point(660, 240);
            orderViewPanel.Controls.Add(order_text);

            Label orderid = new Label();
            orderid.Text = order.orderID.ToString();
            orderid.AutoSize = true;
            orderid.Location = new Point(720, 240);
            orderViewPanel.Controls.Add(orderid);

            Label amountTextlbl = new Label();
            amountTextlbl.Text = "Amount";
            amountTextlbl.AutoSize = true;
            amountTextlbl.Location = new Point(05, 240);
            orderViewPanel.Controls.Add(amountTextlbl);

            ComboBox amount_choice_box = new ComboBox() { Left = 50, Top = 50, Width = 400 };
            amount_choice_box.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            //amount_choice_box.AutoSize = true;
            amount_choice_box.Height = 5;
            amount_choice_box.Width = 50;
            amount_choice_box.Location = new Point(05, 270);
            orderViewPanel.Controls.Add(amount_choice_box);

            Label leave_comment_lbl = new Label();
            leave_comment_lbl.Text = "Leave comment (optional):";
            leave_comment_lbl.AutoSize = true;
            leave_comment_lbl.Location = new Point(100, 240);
            orderViewPanel.Controls.Add(leave_comment_lbl);

            TextBox comment_txt_box = new TextBox();
            comment_txt_box.Height = 10;
            comment_txt_box.Width = 100;
            comment_txt_box.Location = new Point(100, 270);
            orderViewPanel.Controls.Add(comment_txt_box);

            ListView menu = new ListView();
            menu = menuItemService.ShowMenuItems();
            orderViewPanel.Controls.Add(menu);

            ListView incomplitedOrder = new ListView();
            incomplitedOrder = orderItemService.ShowIncompleteOrder(orderItemsList);
            orderViewPanel.Controls.Add(incomplitedOrder);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 47;
            add_btn.Location = new Point(205, 280);
            add_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(add_btn);

            Button remove_btn = new Button();
            remove_btn.Text = "REMOVE ITEM";
            remove_btn.Width = 130;
            remove_btn.Height = 40;
            remove_btn.Location = new Point(400, 240);
            remove_btn.BackColor = Color.LightCoral;
           // orderViewPanel.Controls.Add(remove_btn);

            Button confirm_btn = new Button();
            confirm_btn.Text = "CONFIRM";
            confirm_btn.Width = 166;
            confirm_btn.Height = 47;
            confirm_btn.Location = new Point(570, 280);
            confirm_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(confirm_btn);

            //CONFIRM ORDER click
            confirm_btn.Click += (s, ee) =>
            {
                //if the list of items is empty, show warning message
                if (orderItemsList.Count == 0)
                {
                    MessageBox.Show("Please select an item for a new order");
                    return;
                }

                //send to DB new order items
                orderItemService.AddNewOrderItemsToDB(orderItemsList, order);
                //clear the list of items
                orderItemsList.Clear();
                //load the home page 
                orderForm_Load(s, ee);


            };

            //REMOVE ITEM click
            remove_btn.Click += (s, ee) =>
            {
                //if the list of items is empty, show warning message
                if (incomplitedOrder.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please, select an item from the list to remove it!");
                    return;
                }

                //saving the selected item
                ListViewItem selected = incomplitedOrder.SelectedItems[0];

                //creating an object for removing the same from the orderItemsList
                OrderItems orderItemRemove = new OrderItems();
                orderItemRemove.menuItemID = int.Parse(selected.SubItems[0].Text.ToString());
                orderItemRemove.amount = int.Parse(selected.SubItems[2].Text.ToString());

                //checking which item the same and removing it
                for (int i = 0; i < orderItemsList.Count; i++)
                {
                    if ((orderItemsList[i].amount == orderItemRemove.amount) && (orderItemsList[i].menuItemID == orderItemRemove.menuItemID))
                    {
                        orderItemsList.RemoveAt(i);
                        break;
                    }
                }

                //show newOrder interface with menu and chosen items 
                ShowMenuItemInterface(order);

            };

            //add a new item to the order list (but not sending it to DB yet)
            add_btn.Click += (s, ee) =>
            {

                if (menu.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select an item");
                    return;
                }

                OrderItems orderItemNew = new OrderItems();
                string amount_text = amount_choice_box.SelectedItem.ToString();
                orderItemNew.amount = int.Parse(amount_text);

                ListViewItem selected = menu.SelectedItems[0];
                orderItemNew.menuItemID = int.Parse(selected.SubItems[0].Text.ToString());
                orderItemNew.itemName = selected.SubItems[1].Text.ToString();
                orderItemNew.comment = comment_txt_box.Text;

                orderItemsList.Add(orderItemNew);

                ShowMenuItemInterface(order);
            };
        }


        //new window for a table choice before a creation of a new order
        public static string ShowChooseTable()
        {
            Form message = new Form();
            message.Width = 500;
            message.Height = 300;
            message.Text = "Choose the table for a new order";
            Label textLabel = new Label() { Left = 50, Top = 20, Text = "Table" };
            ComboBox table_choice = new ComboBox() { Left = 50, Top = 50, Width = 400 };
            table_choice.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            table_choice.AutoSize = true;
            Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 100, Top = 90 };
            string text = "";
            confirmation.Click += (sender, e) =>
            {
                if (table_choice.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a table");
                    return;
                }
                text = table_choice.SelectedItem.ToString(); message.Close();
            };
            message.Controls.Add(confirmation);
            message.Controls.Add(textLabel);
            message.Controls.Add(table_choice);
            message.ShowDialog();

            return text;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ordersView_Click(object sender, EventArgs e)
        {
            orderForm_Load(sender, e);

        }

        public ListView tablesListView;

        private TableService tableService = new TableService();
  
        // show tables
        private void TablesViewBtn_Click(object sender, EventArgs e)
        {
            createNew.Enabled = true;
            orderViewPanel.Controls.Clear();
            ShowTables();
            ShowRestaurantView();
        }

        private void ShowRestaurantView()
        {
            orderViewPanel.BackgroundImage =
                new Bitmap(Application.StartupPath + "\\RV.png");
            orderViewPanel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowTables()
        {
            List<Table> tables = tableService.GetTables();
            int lastX = 73;
            int y = 50;

            // store even table numbers
            for (int i = 0; i < tables.Count; i++)
            {
                Button btn = new Button();

                if ((i + 1) % 2 == 0)
                {
                    btn.Size = new Size(100, 50);
                    btn.Location = new Point(lastX, y);
                    orderViewPanel.Controls.Add(btn);
                    lastX += btn.Width + 36;
                    btn.Text = (i + 1).ToString();
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i];
                }
                if (tables[i].occupied == true)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
            }

            // store odd table numbers
            lastX = 73;
            y = 200;
            for (int i = 0; i < tables.Count; i++)
            {
                Button btn = new Button();

                if ((i + 1) % 2 != 0)
                {
                    btn.Size = new Size(100, 50);
                    btn.Location = new Point(lastX, y);
                    orderViewPanel.Controls.Add(btn);
                    lastX += btn.Width + 36;
                    btn.Text = (i + 1).ToString();
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i];
                }
                if (tables[i].occupied == true)
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.AliceBlue;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
            }

        }

        // change tables status
        private void changeTableStatusBtn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Table table = (Table)button.Tag;
            int tableID = table.tableID;
            bool occupied;

            if (MessageBox.Show("Would you like to change the status of table [" + table.tableID + "]?", "Change Table Status",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (table.occupied)
                {
                    occupied = false;
                }
                else
                {
                    occupied = true;
                }
                tableService.ChangeTableStatus(new Table(tableID, occupied));
            }
            orderViewPanel.Controls.Clear();
            ShowTables();
        }

        // log off link
        private void logoffLink_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to log off?", "Logging off",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void orderForm_Load(object sender, EventArgs e)
        {

        }

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
