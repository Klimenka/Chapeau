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




namespace ChapeauUI
{
    public partial class orderForm : Form
    {

        OrderItemsService orderItemService = new OrderItemsService();
        OrderService orderService = new OrderService();
        MenuItemService menuItemService = new MenuItemService();
        TableService tableService = new TableService();
        List<OrderItems> orderItemsList = new List<OrderItems>();
        


        public orderForm(int ID, string employeeName, Position employeePosition)
        {
            InitializeComponent();
            Shown += orderForm_Load;

            // show the name of the user who logged in
            empNameLbl.Text = "[" + employeeName + " <" + employeePosition + ">" + "]";

            //save the employee ID on the form
            employeeID.Text = ID.ToString();
        }

        //show home page for a waiter
        private void orderForm_Load(object sender, EventArgs e)
        {
            createNew.Enabled = true;
            orderViewPanel.Controls.Clear();

            ListView showOrderItems = new ListView();
            showOrderItems = ShowOrderItems(int.Parse(employeeID.Text));
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
            find_order_by_table.Height = 50;
            find_order_by_table.Location = new Point(560, 75);
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
            served.Text = "SERVED";
            served.Width = 166;
            served.Height = 50;
            served.Location = new Point(350, 265);
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
            existedOrderListControl = ShowOrderItemsExisted(existedOrder);
            orderViewPanel.Controls.Add(existedOrderListControl);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 50;
            add_btn.Location = new Point(30, 265);
            // add_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(add_btn);

            Button payment_btn = new Button();
            payment_btn.Text = "PAYMENT";
            payment_btn.Width = 166;
            payment_btn.Height = 50;
            payment_btn.Location = new Point(590, 265);
            payment_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(payment_btn);

            Label subtotal_lbl = new Label();
            subtotal_lbl.Text = "Subtotal: ";
            subtotal_lbl.AutoSize = true;
            subtotal_lbl.Location = new Point(317, 230);
            orderViewPanel.Controls.Add(subtotal_lbl);

            Label subtotal_value_lbl = new Label();
            subtotal_value_lbl.Text = orderItemService.subtotalPrice.ToString("0.00") + " euro";
            subtotal_value_lbl.AutoSize = true;
            subtotal_value_lbl.Location = new Point(400, 230);
            orderViewPanel.Controls.Add(subtotal_value_lbl);

            if (orderItemService.VAT_06 != 0)
            {
                Label VAT_06_lbl = new Label();
                VAT_06_lbl.Text = "VAT 0.06 %: ";
                VAT_06_lbl.AutoSize = true;
                VAT_06_lbl.Location = new Point(317, 250);
                orderViewPanel.Controls.Add(VAT_06_lbl);

                Label VAT_06_value_lbl = new Label();
                VAT_06_value_lbl.Text = orderItemService.VAT_06.ToString("0.00") + " euro";
                VAT_06_value_lbl.AutoSize = true;
                VAT_06_value_lbl.Location = new Point(400, 250);
                orderViewPanel.Controls.Add(VAT_06_value_lbl);
            }

            if (orderItemService.VAT_21 != 0)
            {
                Label VAT_21_lbl = new Label();
                VAT_21_lbl.Text = "VAT 0.21 %: ";
                VAT_21_lbl.AutoSize = true;
                VAT_21_lbl.Location = new Point(317, 270);
                orderViewPanel.Controls.Add(VAT_21_lbl);

                Label VAT_21_value_lbl = new Label();
                VAT_21_value_lbl.Text = orderItemService.VAT_21.ToString("0.00") + " euro";
                VAT_21_value_lbl.AutoSize = true;
                VAT_21_value_lbl.Location = new Point(400, 270);
                orderViewPanel.Controls.Add(VAT_21_value_lbl);
            }

            

            Label totalPrice_lbl = new Label();
            totalPrice_lbl.Text = "Total price: ";
            totalPrice_lbl.AutoSize = true;
            totalPrice_lbl.Location = new Point(317, 300);
            orderViewPanel.Controls.Add(totalPrice_lbl);

            Label totalPrice_value_lbl = new Label();
            totalPrice_value_lbl.Text = orderItemService.totalPrice.ToString("0.00") + " euro";
            totalPrice_value_lbl.AutoSize = true;
            totalPrice_value_lbl.Location = new Point(400, 300);
            orderViewPanel.Controls.Add(totalPrice_value_lbl);


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
            orderViewPanel.BackgroundImage = null;
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

        public ListView ShowOrderItems(int ID)
        {
            List<OrderItems> orders = orderItemService.GetOrderItems(ID);

            // Making a list and editing its format 
            ListView ordersListView = new ListView();
            ordersListView.Height = 250;
            ordersListView.Width = 500;
            ordersListView.Left = 30;
            ordersListView.View = View.Details;
            ordersListView.FullRowSelect = true;
            ordersListView.CheckBoxes = true;
            ordersListView.MultiSelect = true;

            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "OrderID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 75;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Table";
            headerSecond.Width = 45;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Name";
            headerThird.Width = 150;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Amount";
            headerFourth.Width = 70;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Task";
            headerFifth.Width = 150;


            // adding colums to the list
            ordersListView.Columns.Add(headerFirst);
            ordersListView.Columns.Add(headerSecond);
            ordersListView.Columns.Add(headerThird);
            ordersListView.Columns.Add(headerFourth);
            ordersListView.Columns.Add(headerFifth);

            // storing data into the list
            foreach (OrderItems item in orders)
            {
                if (item.isServed == false && item.isReady == true)
                {
                    ListViewItem entryListItem = ordersListView.Items.Add(item.orderItemID.ToString());
                    entryListItem.SubItems.Add(item.tableID.ToString());
                    entryListItem.SubItems.Add(item.itemName);
                    entryListItem.SubItems.Add(item.amount.ToString());
                    entryListItem.SubItems.Add("Needs to be served");

                }
                else
                    continue;

            }

            // return a list view 
            return ordersListView;
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
            amountTextlbl.Location = new Point(25, 240);
            orderViewPanel.Controls.Add(amountTextlbl);

            ComboBox amount_choice_box = new ComboBox() { Left = 50, Top = 50, Width = 400 };
            amount_choice_box.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            //amount_choice_box.AutoSize = true;
            amount_choice_box.Height = 5;
            amount_choice_box.Width = 50;
            amount_choice_box.Location = new Point(25, 270);
            orderViewPanel.Controls.Add(amount_choice_box);

            Label leave_comment_lbl = new Label();
            leave_comment_lbl.Text = "Leave comment (optional):";
            leave_comment_lbl.AutoSize = true;
            leave_comment_lbl.Location = new Point(125, 240);
            orderViewPanel.Controls.Add(leave_comment_lbl);

            TextBox comment_txt_box = new TextBox();
            comment_txt_box.Height = 10;
            comment_txt_box.Width = 100;
            comment_txt_box.Location = new Point(125, 270);
            orderViewPanel.Controls.Add(comment_txt_box);

            ListView menu = new ListView();
            menu = ShowMenuItems();
            orderViewPanel.Controls.Add(menu);

            ListView incomplitedOrder = new ListView();
            incomplitedOrder = ShowIncompleteOrder(orderItemsList);
            orderViewPanel.Controls.Add(incomplitedOrder);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 50;
            add_btn.Location = new Point(235, 280);
            add_btn.BackColor = Color.LightGreen;
            orderViewPanel.Controls.Add(add_btn);

            Button remove_btn = new Button();
            remove_btn.Text = "REMOVE ITEM";
            remove_btn.Width = 130;
            remove_btn.Height = 50;
            remove_btn.Location = new Point(400, 240);
            remove_btn.BackColor = Color.LightCoral;
            // orderViewPanel.Controls.Add(remove_btn);

            Button confirm_btn = new Button();
            confirm_btn.Text = "CONFIRM";
            confirm_btn.Width = 166;
            confirm_btn.Height = 50;
            confirm_btn.Location = new Point(605, 280);
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

        public ListView ShowIncompleteOrder(List<OrderItems> items)
        {
            ListView itemsListView = new ListView();
            itemsListView.Height = 230;
            itemsListView.Width = 350;
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;
            itemsListView.Left = 420;



            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 30;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 150;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Amount";
            headerThird.Width = 40;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Comment";
            headerFourth.Width = 100;

            // adding colums to the list
            itemsListView.Columns.Add(headerFirst);
            itemsListView.Columns.Add(headerSecond);
            itemsListView.Columns.Add(headerThird);
            itemsListView.Columns.Add(headerFourth);


            // storing data into the list
            foreach (OrderItems item in items)
            {
                ListViewItem entryListItem = new ListViewItem();
                entryListItem = itemsListView.Items.Add(item.menuItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.amount.ToString());
                entryListItem.SubItems.Add(item.comment);

            }

            // return a list view 
            return itemsListView;

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
            orderViewPanel.BackgroundImage = null;
            orderForm_Load(sender, e);
        }

        public ListView ShowMenuItems()
        {
            // Making a list and editing its format 
            ListView MenuItemsListView = new ListView();
            List<ChapeauModel.MenuItem> menuItems = menuItemService.GetMenuItems();
            MenuItemsListView.Height = 230;
            MenuItemsListView.Width = 365;
            MenuItemsListView.Left = 30;
            MenuItemsListView.View = View.Details;
            MenuItemsListView.FullRowSelect = true;
            MenuItemsListView.HideSelection = false;
            MenuItemsListView.Select();


            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 45;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 170;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Stock";
            headerThird.Width = 50;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Bar Or Kitchen";
            headerFourth.Width = 75;

            // adding colums to the list
            MenuItemsListView.Columns.Add(headerFirst);
            MenuItemsListView.Columns.Add(headerSecond);
            MenuItemsListView.Columns.Add(headerThird);
            MenuItemsListView.Columns.Add(headerFourth);

            // storing data into the list
            foreach (ChapeauModel.MenuItem item in menuItems)
            {

                ListViewItem entryListItem = new ListViewItem();
                entryListItem = MenuItemsListView.Items.Add(item.menuItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.amountOnStock.ToString());
                if (item.barOrKitchen == false)
                {
                    entryListItem.SubItems.Add("Bar");
                }
                else
                {
                    entryListItem.SubItems.Add("Kitchen");
                }
            }

            // return a list view 
            return MenuItemsListView;

        }

        public ListView ShowOrderItemsExisted(Order existedOrder)
        {
            List<OrderItems> orderItems = orderItemService.OrderItemsExistedLogic(existedOrder);
            List<ChapeauModel.MenuItem> menuItems = menuItemService.GetMenuItems();

            ListView itemsListView = new ListView();
            itemsListView.Height = 200;
            itemsListView.Width = 730;
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;
            itemsListView.Left = 30;


            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();
            ColumnHeader headerSixth = new ColumnHeader();
            ColumnHeader headerSeventh = new ColumnHeader();


            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 70;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 260;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Price";
            headerThird.Width = 80;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Amount";
            headerFourth.Width = 70;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "TotalPrice";
            headerFifth.Width = 80;

            headerSixth.TextAlign = HorizontalAlignment.Left;
            headerSixth.Text = "Comment";
            headerSixth.Width = 100;

            headerSeventh.TextAlign = HorizontalAlignment.Left;
            headerSeventh.Text = "Is served?";
            headerSeventh.Width = 85;

            // adding colums to the list
            itemsListView.Columns.Add(headerFirst);
            itemsListView.Columns.Add(headerSecond);
            itemsListView.Columns.Add(headerThird);
            itemsListView.Columns.Add(headerFourth);
            itemsListView.Columns.Add(headerFifth);
            itemsListView.Columns.Add(headerSixth);
            itemsListView.Columns.Add(headerSeventh);

            // storing data into the list
            foreach (OrderItems item in orderItems)
            {
                ListViewItem entryListItem = new ListViewItem();
                entryListItem = itemsListView.Items.Add(item.orderItemID.ToString());
                entryListItem.SubItems.Add(menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).itemName);

                float price = menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).price;
                //add to listControl
                entryListItem.SubItems.Add(price.ToString("0.00"));
                entryListItem.SubItems.Add(item.amount.ToString());

                //calculate amount*price
                float priceForItem = item.amount * price;
                entryListItem.SubItems.Add(priceForItem.ToString("0.00"));
                entryListItem.SubItems.Add(item.comment);
                if (item.isServed == true)
                {
                    entryListItem.SubItems.Add("Yes");
                }
                else
                {
                    entryListItem.SubItems.Add("No");
                }

            }

            // return a list view 
            return itemsListView;

        }


        /*********************** Restaurant/table********************************/
        /********************* view ***********************/


        private void TablesViewBtn_Click(object sender, EventArgs e)
        {
            createNew.Enabled = true; // enable Create New button
            orderViewPanel.Controls.Clear(); // clear the panel
            ShowTables();   // show tables
            ShowRestaurantView(); // show Restaurant view
        }

        private void ShowRestaurantView()
        {
            // add background image to the panel
            orderViewPanel.BackgroundImage =
                new Bitmap(Application.StartupPath + "\\RV.png");
            orderViewPanel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowTables()
        {
            List<Table> tables = tableService.GetTables(); // get the table list
            int lastX = 73; // starting X position for creating the buttons
            int y = 50; // starting Y position

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

                    // create event handler for the buttons
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i]; // link the table object to the button
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

                    // create event handler for the buttons
                    btn.Click += new EventHandler(changeTableStatusBtn_Click);
                    btn.Tag = tables[i]; // link the table object to the button
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
            Table table = (Table)button.Tag; // store data in table from the button tag
            int tableID = table.tableID;
            bool occupied;

            // show a message to know if the user want to change the table status or not
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
                tableService.ChangeTableStatus(new Table(tableID, occupied)); // pass data to the logic layer
            }
            orderViewPanel.Controls.Clear(); // clear the panel
            ShowTables(); // show the updated tables again
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

        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // exit the whole app
        }



    }
}
