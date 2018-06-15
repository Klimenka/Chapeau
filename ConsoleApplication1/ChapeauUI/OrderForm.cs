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
using ContentAlignment = System.Drawing.ContentAlignment;

namespace ChapeauUI
{
    public partial class orderForm : Form
    {
        int flag_timer = 0; // 0 - initial form (tables view), 1 - orders_view
        OrderService orderService = new OrderService();
        MenuItemService menuItemService = new MenuItemService();
        TableService tableService = new TableService();
        List<OrderItems> orderItemsList = new List<OrderItems>();
        
        
        public orderForm(Employess employee, Form form)
        {
            InitializeComponent();
            // show the name of the user who logged in
            empNameLbl.Text = @"[" + employee.EmployeeName + @" <" + (Position)employee.position + @">" + @"]";

            //save the employee ID on the form
            employeeID.Text = employee.employeeID.ToString();
            
            // Instantiate the timer
           
            Timer t = new Timer();

            t.Interval = 10000;

            t.Enabled = true;

            t.Tick += new System.EventHandler(OnTimerEvent);
        }

        private void OnTimerEvent(object sender, EventArgs e)

        {
            if (flag_timer == 1)
            {
                orderForm_Load(sender, e);
            }
            else if (flag_timer == 0)
            {
                TablesViewBtn_Click(sender, e);
            }

        }

        //show home page for a waiter(for serving purpose)
        private void orderForm_Load(object sender, EventArgs e)
        {
            flag_timer = 1;
            orderViewPanel.Controls.Clear();

            //items that need to be served
            ListView showOrderItems = new ListView();
            showOrderItems = ShowOrderItems(int.Parse(employeeID.Text));
            orderViewPanel.Controls.Add(showOrderItems);

            Button served = new Button();
            served.Text = "SERVED";
            served.Width = 166;
            served.Height = 50;
            served.ForeColor = Color.White;
            served.BackColor = Color.Green;
            served.Location = new Point(550, 245);
            orderViewPanel.Controls.Add(served);

            served.Click += (s, ee) =>
            {
                //if the list of items is empty, show warning message
                if (showOrderItems.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please select items to be served");
                    return;
                }

                //save checked ItemsIDs
                int[] checkedItems = new int[showOrderItems.CheckedItems.Count];
                for (int i = 0; i < showOrderItems.CheckedItems.Count; i++)
                {
                    checkedItems[i] = int.Parse(showOrderItems.CheckedItems[i].SubItems[0].Text.ToString());
                }

                //send to DB items for the update
                orderService.CheckAsServed(checkedItems);


                orderForm_Load(s, ee);
            };
        }


        //Show an existed order (a table number is required)
        private void ShowExistedOrder(Order existedOrder)
        {
            flag_timer = 2;
            orderViewPanel.BackgroundImage = null;

            orderViewPanel.Controls.Clear();

            //getting orderID by tableID (from DB)
            existedOrder.orderID = orderService.GetOrderID(existedOrder.tableID);

            //show items from an existed order
            ListView existedOrderListControl = new ListView();
            existedOrderListControl = ShowOrderItemsExisted(existedOrder);
            orderViewPanel.Controls.Add(existedOrderListControl);

            //creating the buttons and labels
            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 50;
            add_btn.Location = new Point(30, 220);
            add_btn.ForeColor = Color.White;
            add_btn.BackColor = Color.Green;
            orderViewPanel.Controls.Add(add_btn);

            Button cancel_btn = new Button();
            cancel_btn.Text = "CANCEL";
            cancel_btn.Width = 120;
            cancel_btn.Height = 45;
            cancel_btn.Location = new Point(05, 290);
            cancel_btn.BackColor = Color.Red;
            orderViewPanel.Controls.Add(cancel_btn);

            Button payment_btn = new Button();
            payment_btn.Text = "PAYMENT";
            payment_btn.Width = 166;
            payment_btn.Height = 50;
            payment_btn.Location = new Point(594, 220);
            payment_btn.ForeColor = Color.White;
            payment_btn.BackColor = Color.Green;
            orderViewPanel.Controls.Add(payment_btn);

            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(377, 210);
            orderViewPanel.Controls.Add(table);

            Label chosen_table = new Label();
            chosen_table.Text = existedOrder.tableID.ToString();
            chosen_table.AutoSize = true;
            chosen_table.Location = new Point(460, 210);
            orderViewPanel.Controls.Add(chosen_table);

            Label subtotal_lbl = new Label();
            subtotal_lbl.Text = "Subtotal: ";
            subtotal_lbl.AutoSize = true;
            subtotal_lbl.Location = new Point(377, 230);
            orderViewPanel.Controls.Add(subtotal_lbl);

            Label subtotal_value_lbl = new Label();
            subtotal_value_lbl.Text = orderService.subtotalPrice.ToString("0.00") + " euro";
            subtotal_value_lbl.AutoSize = true;
            subtotal_value_lbl.Location = new Point(460, 230);
            orderViewPanel.Controls.Add(subtotal_value_lbl);

            //if items with 0.06% VAT exists ----> add to the label
            if (orderService.VAT_06 != 0)
            {
                Label VAT_06_lbl = new Label();
                VAT_06_lbl.Text = "VAT 0.06 %: ";
                VAT_06_lbl.AutoSize = true;
                VAT_06_lbl.Location = new Point(377, 250);
                orderViewPanel.Controls.Add(VAT_06_lbl);

                Label VAT_06_value_lbl = new Label();
                VAT_06_value_lbl.Text = orderService.VAT_06.ToString("0.00") + " euro";
                VAT_06_value_lbl.AutoSize = true;
                VAT_06_value_lbl.Location = new Point(460, 250);
                orderViewPanel.Controls.Add(VAT_06_value_lbl);
            }

            //if items with 0.21% VAT exists ----> add to the label
            if (orderService.VAT_21 != 0)
            {
                Label VAT_21_lbl = new Label();
                VAT_21_lbl.Text = "VAT 0.21 %: ";
                VAT_21_lbl.AutoSize = true;
                VAT_21_lbl.Location = new Point(377, 270);
                orderViewPanel.Controls.Add(VAT_21_lbl);

                Label VAT_21_value_lbl = new Label();
                VAT_21_value_lbl.Text = orderService.VAT_21.ToString("0.00") + " euro";
                VAT_21_value_lbl.AutoSize = true;
                VAT_21_value_lbl.Location = new Point(460, 270);
                orderViewPanel.Controls.Add(VAT_21_value_lbl);
            }


            //Total price
            Label totalPrice_lbl = new Label();
            totalPrice_lbl.Text = "Total price: ";
            totalPrice_lbl.AutoSize = true;
            totalPrice_lbl.Location = new Point(377, 300);
            orderViewPanel.Controls.Add(totalPrice_lbl);

            Label totalPrice_value_lbl = new Label();
            totalPrice_value_lbl.Text = orderService.totalPrice.ToString("0.00") + " euro";
            totalPrice_value_lbl.AutoSize = true;
            totalPrice_value_lbl.Location = new Point(460, 300);
            orderViewPanel.Controls.Add(totalPrice_value_lbl);

            //*****Button clicks*****

            payment_btn.Click += (s, ee) =>
            {
                TablesViewBtn_Click(s, ee);

                existedOrder.employeeID = Convert.ToInt32(employeeID.Text);
                PaymentForm paymentForm = new PaymentForm(existedOrder, orderService.totalPrice, this);
                paymentForm.Show();
               
            };

            add_btn.Click += (s, ee) =>
            {
                ShowMenuItemInterface(existedOrder);

            };

            cancel_btn.Click += (s, ee) =>
            {
                TablesViewBtn_Click(s, ee);
            };

        }



        //create a new order
        private void ShowMenuItemInterface(Order order)
        {
            flag_timer = 2;
            ordersView.Enabled = false;
            tablesViewBtn.Enabled = false;

            orderViewPanel.BackgroundImage = null;

            orderViewPanel.Controls.Clear();

            //creating the buttons and labels
            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(570, 180);
            orderViewPanel.Controls.Add(table);

            Label chosen_table = new Label();
            chosen_table.Text = order.tableID.ToString();
            chosen_table.AutoSize = true;
            chosen_table.Location = new Point(610, 180);
            orderViewPanel.Controls.Add(chosen_table);

            Button cancel_btn = new Button();
            cancel_btn.Text = "CANCEL";
            cancel_btn.Width = 140;
            cancel_btn.Height = 47;
            cancel_btn.Location = new Point(05, 290);
            cancel_btn.BackColor = Color.Red;
            orderViewPanel.Controls.Add(cancel_btn);

            Label amountTextlbl = new Label();
            amountTextlbl.Text = "Amount";
            amountTextlbl.AutoSize = true;
            amountTextlbl.Location = new Point(320, 00);
            orderViewPanel.Controls.Add(amountTextlbl);

            ComboBox amount_choice_box = new ComboBox();
            amount_choice_box.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            amount_choice_box.AutoSize = true;
            amount_choice_box.SelectedIndex = 0;
            amount_choice_box.Height = 10;
            amount_choice_box.Width = 60;
            amount_choice_box.Location = new Point(320, 40);
            orderViewPanel.Controls.Add(amount_choice_box);

            Label leave_comment_lbl = new Label();
            leave_comment_lbl.Text = "Comment (optional):";
            leave_comment_lbl.AutoSize = true;
            leave_comment_lbl.Location = new Point(320, 100);
            orderViewPanel.Controls.Add(leave_comment_lbl);

            TextBox comment_txt_box = new TextBox();
            comment_txt_box.Height = 10;
            comment_txt_box.Width = 100;
            comment_txt_box.Location = new Point(320, 140);
            orderViewPanel.Controls.Add(comment_txt_box);

            //menu from DB
            ListView menu = new ListView();
            menu = ShowMenuItems();
            orderViewPanel.Controls.Add(menu);

            //selected items (for a new order (not in DB yet))
            ListView incomplitedOrder = new ListView();
            incomplitedOrder = ShowIncompleteOrder(orderItemsList);
            orderViewPanel.Controls.Add(incomplitedOrder);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 150;
            add_btn.Height = 50;
            add_btn.Location = new Point(310, 180);
            add_btn.ForeColor = Color.White;
            add_btn.BackColor = Color.Green;
            orderViewPanel.Controls.Add(add_btn);

            Button remove_btn = new Button();
            remove_btn.Text = "REMOVE ITEM";
            remove_btn.Width = 130;
            remove_btn.Height = 47;
            remove_btn.Location = new Point(650, 180);
            orderViewPanel.Controls.Add(remove_btn);

            Button confirm_btn = new Button();
            confirm_btn.Text = "CONFIRM";
            confirm_btn.Width = 166;
            confirm_btn.Height = 50;
            confirm_btn.Location = new Point(605, 280);
            confirm_btn.ForeColor = Color.White;
            confirm_btn.BackColor = Color.Green;
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
                orderService.AddNewOrderItemsToDB(orderItemsList, order);

                //clear the list of items
                orderItemsList.Clear();
                ordersView.Enabled = true;
                tablesViewBtn.Enabled = true;
                //load the tables_view page 
                TablesViewBtn_Click(s, ee);
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


            cancel_btn.Click += (s, ee) =>
            {
                //if we are trying to add items in an existed order, we cannot delete the order, so we need to check it
                if (!orderService.CheckIfExistedOrder(order.orderID))
                {
                    orderService.DeleteOrder(order);
                }

                ordersView.Enabled = true;
                tablesViewBtn.Enabled = true;
                TablesViewBtn_Click(s, ee);

                //if ()
                //{
                    
                //}
            };
        }

        //ListView for items what need to be served
        private ListView ShowOrderItems(int ID)
        {
            List<Order> orders = orderService.GetOrderItems(ID);

            //for separate colors
            int counter1 = 0;
            int counter2 = 0;
            bool flag = false;

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
            headerFirst.Text = "ID";
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
            foreach (Order item in orders)
            {
                //if items are needed to be served
                if (item.items[0].isServed == false && item.items[0].isReady == true)
                {
                    //if it's the first unserved order OR we need to reset counters
                    if (counter1 == 0 || (counter1 != item.orderID && counter2 != item.orderID && flag == true))
                    {
                        counter1 = item.orderID;
                        flag = false;
                    }


                    if (counter1 == item.orderID)
                    {
                        ListViewItem entryListItem = ordersListView.Items.Add(item.items[0].orderItemID.ToString());
                        entryListItem.BackColor = Color.LightBlue;
                        entryListItem.SubItems.Add(item.tableID.ToString());
                        entryListItem.SubItems.Add(item.items[0].itemName);
                        entryListItem.SubItems.Add(item.items[0].amount.ToString());
                        entryListItem.SubItems.Add("Needs to be served");

                    }
                    else
                    {
                        counter2 = item.orderID;
                        flag = true;
                        ListViewItem entryListItem = ordersListView.Items.Add(item.items[0].orderItemID.ToString());
                        entryListItem.BackColor = Color.LightYellow;
                        entryListItem.SubItems.Add(item.tableID.ToString());
                        entryListItem.SubItems.Add(item.items[0].itemName);
                        entryListItem.SubItems.Add(item.items[0].amount.ToString());
                        entryListItem.SubItems.Add("Needs to be served");
                    }
                }
                else
                    continue;
            }

            // return a list view 
            return ordersListView;
        }

        //listView for incomplete order 
        private ListView ShowIncompleteOrder(List<OrderItems> items)
        {
            ListView itemsListView = new ListView();
            itemsListView.Height = 165;
            itemsListView.Width = 330;
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;
            itemsListView.Left = 450;
            
            
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
            headerSecond.Width = 160;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Amount";
            headerThird.Width = 50;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Comment";
            headerFourth.Width = 80;

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

        //Button_click (Needs to be served)
        private void ordersView_Click(object sender, EventArgs e)
        {
            orderViewPanel.BackgroundImage = null;
            orderForm_Load(sender, e);
        }

        //listView for the menu
        private ListView ShowMenuItems()
        {
            // Making a list and editing its format 
            ListView MenuItemsListView = new ListView();
            List<ChapeauModel.MenuItem> menuItems = menuItemService.GetMenuItems();
            MenuItemsListView.Height = 230;
            MenuItemsListView.Width = 280;
            MenuItemsListView.Left = 30;
            MenuItemsListView.View = View.Details;
            MenuItemsListView.FullRowSelect = true;
            MenuItemsListView.HideSelection = false;
            MenuItemsListView.Select();


            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();


            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 37;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 170;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Stock";
            headerThird.Width = 50;



            // adding colums to the list
            MenuItemsListView.Columns.Add(headerFirst);
            MenuItemsListView.Columns.Add(headerSecond);
            MenuItemsListView.Columns.Add(headerThird);


            // storing data into the list
            foreach (ChapeauModel.MenuItem item in menuItems)
            {

                ListViewItem entryListItem = new ListViewItem();
                entryListItem = MenuItemsListView.Items.Add(item.menuItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.amountOnStock.ToString());

            }

            // return a list view 
            return MenuItemsListView;

        }

        //listview for an existed order
        private ListView ShowOrderItemsExisted(Order existedOrder)
        {
            List<OrderItems> orderItems = orderService.OrderItemsExistedLogic(existedOrder);
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
            headerSecond.Width = 250;

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


        public void TablesViewBtn_Click(object sender, EventArgs e)
        {
            flag_timer = 0;
            orderViewPanel.Controls.Clear(); // clear the panel
            ShowTables();   // show tables
            ShowRestaurantView(); // show Restaurant view

        }


        private void ShowRestaurantView()
        {
            // add background image to the panel
            orderViewPanel.BackgroundImage=
                new Bitmap(Application.StartupPath + "\\RV.png");
            orderViewPanel.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void ShowTables()
        {
            List<Table> tables = tableService.GetTables(); // get the table list

            int lastX = 100; // starting X position for creating the buttons
            int y = 40; // starting Y position

            // store even table numbers
            for (int i = 0; i < tables.Count; i++)
            {
                PictureBox pbtnBox = new PictureBox // object initializer
                {
                    Size = new Size(70, 50),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Cursor = Cursors.Hand
                };

                Label lbl = new Label
                {
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                if ((i + 1) % 2 == 0)
                {

                    pbtnBox.Location = new Point(lastX, y);
                    lbl.Location = new Point(lastX, 95);
                    lastX += pbtnBox.Width + 70;

                    // create event handler for the buttons
                    pbtnBox.Click += new EventHandler(changeTableStatusPBtnBox_Click);
                    pbtnBox.Tag = tables[i]; // link the table object to the button
                }
                else
                {
                    continue;
                }

                if (tables[i].occupied == true)
                {
                    lbl.Text = (i + 1) + "\nReserved";
                    pbtnBox.ImageLocation = @"c:tableRed.png";
                }
                else
                {
                    lbl.Text = (i + 1) + "\nUn-Reserved";
                    pbtnBox.ImageLocation = @"c:tableGreen.png";
                }
                orderViewPanel.Controls.Add(pbtnBox);
                orderViewPanel.Controls.Add(lbl);
            }

            // store odd table numbers
            lastX = 100;
            y = 170;
            for (int i = 0; i < tables.Count; i++)
            {
                PictureBox pbtnBox = new PictureBox
                {
                    Size = new Size(70, 50),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Cursor = Cursors.Hand
                };

                Label lbl = new Label
                {
                    Size = new Size(70, 30),
                    TextAlign = ContentAlignment.MiddleCenter
                };

                if ((i + 1) % 2 != 0)
                {
                    pbtnBox.Location = new Point(lastX, y);
                    lbl.Location = new Point(lastX, 225);
                    lastX += pbtnBox.Width + 70;
                    // create event handler for the buttons
                    pbtnBox.Click += new EventHandler(changeTableStatusPBtnBox_Click);
                    pbtnBox.Tag = tables[i]; // link the table object to the button
                }
                else
                {
                    continue;
                }

                if (tables[i].occupied == true)
                {
                    lbl.Text = (i + 1) + "\nReserved";
                    pbtnBox.ImageLocation = @"c:tableRed.png";
                }
                else
                {
                    pbtnBox.ImageLocation = @"c:tableGreen.png";
                    lbl.Text = (i + 1) + "\nUn-Reserved"; 
                }
                orderViewPanel.Controls.Add(pbtnBox);
                orderViewPanel.Controls.Add(lbl);
            }
           
        }

        // change tables status
        private void changeTableStatusPBtnBox_Click(object sender, EventArgs e)
        {
            PictureBox button = sender as PictureBox;
            Table table = (Table)button.Tag; // store data in table from the button tag
          

            Order order = new Order();

            if (table.occupied)
            {
                //show an existed order
                order.tableID = table.tableID;
                ShowExistedOrder(order);
            }
            else
            {
                //create a new order
                order = orderService.NewOrder(int.Parse(employeeID.Text), table.tableID);
                ShowMenuItemInterface(order);
            }

        }

        // log off link
        private void logoffLink_Click(object sender, EventArgs e)
        {
            // to show a confirmation message
            if (MessageBox.Show(@"Are you sure you want to log off?", @"Logging off",
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
