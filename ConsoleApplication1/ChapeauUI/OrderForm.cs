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

        //TextBox comment_txt_box = new TextBox();

        //ComboBox amount_choice_box = new ComboBox() { Left = 50, Top = 50, Width = 400 };

        public orderForm(int ID)
        {
            InitializeComponent();
            Shown += orderForm_Load;

            //save the employee ID on the form
            employeeID.Text = ID.ToString();
        }
        
        private void orderForm_Load(object sender, EventArgs e)
        {
            orderViewPanel.Controls.Clear();
            orderViewPanel.Controls.Add(orderItemService.ShowOrderItems(int.Parse(employeeID.Text)));

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

            Button served = new Button();
            served.Text = "Served";
            served.Width = 166;
            served.Height = 47;
            served.Location = new Point(285, 265);
            orderViewPanel.Controls.Add(served);
            served.Click += new EventHandler(served_clicked);
        }

        private void served_clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        

        //new order button click
        private void createNew_Click(object sender, EventArgs e)
        {
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

        public void ShowMenuItemInterface (Order order)
        {
            orderViewPanel.Controls.Clear();

            //saving data on the panel (creation of the buttons and labels)
            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(450, 240);
            orderViewPanel.Controls.Add(table);

            Label chosen_table = new Label();
            chosen_table.Text = order.tableID.ToString();
            chosen_table.AutoSize = true;
            chosen_table.Location = new Point(500, 240);
            orderViewPanel.Controls.Add(chosen_table);

            Label order_text = new Label();
            order_text.Text = "Order: ";
            order_text.AutoSize = true;
            order_text.Location = new Point(540, 240);
            orderViewPanel.Controls.Add(order_text);

            Label orderid = new Label();
            orderid.Text = order.orderID.ToString();
            orderid.AutoSize = true;
            orderid.Location = new Point(600, 240);
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

            ListView uncomplitedOrder = new ListView();
            uncomplitedOrder = orderItemService.ShowUncompleteOrder(orderItemsList);
            orderViewPanel.Controls.Add(uncomplitedOrder);

            Button add_btn = new Button();
            add_btn.Text = "ADD TO ORDER";
            add_btn.Width = 166;
            add_btn.Height = 47;
            add_btn.Location = new Point(250, 280);
            orderViewPanel.Controls.Add(add_btn);

            Button confirm_btn = new Button();
            confirm_btn.Text = "CONFIRM";
            confirm_btn.Width = 166;
            confirm_btn.Height = 47;
            confirm_btn.Location = new Point(650, 280);
            orderViewPanel.Controls.Add(confirm_btn);

            confirm_btn.Click += (s, ee) =>
            {
                if (orderItemsList.Count == 0)
                {
                    MessageBox.Show("Please select items for a new order");
                    return;
                }


                orderItemService.AddNewOrderItemsToDB(orderItemsList, order);
                orderForm_Load(s, ee);


            };

            //add a new item to the order list (but not sending it to DB yet)
            add_btn.Click += (s, ee) =>
            {
                if (amount_choice_box.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select an amount");
                    return;
                }

                OrderItems orderItemNew = new OrderItems();
                string amount_text = amount_choice_box.SelectedItem.ToString();
                orderItemNew.amount = int.Parse(amount_text);

                var index = menu.CheckedIndices;
                int menuItemIndex = index[0];
               
                 
                orderItemNew.menuItemID = menuItemIndex + 1;
                orderItemNew.comment = comment_txt_box.Text;
                string itemName = menuItemService.FindItemNameByIndex(menuItemIndex);
                orderItemNew.itemName = itemName;



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
            confirmation.Click += (sender, e) => {
                if (table_choice.SelectedIndex == -1)
                {
                    MessageBox.Show("Please select a value");
                    return;
                }
                text = table_choice.SelectedItem.ToString(); message.Close();};
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

        private void TablesViewBtn_Click(object sender, EventArgs e)
        {
            orderViewPanel.Controls.Clear();
            orderViewPanel.Controls.Add(CreateChnageTableStatusBtn());
            orderViewPanel.Controls.Add(ShowTables());
        }

        private Control ShowTables()
        {
            tablesListView = new ListView();
            tablesListView.Width = orderViewPanel.Width;
            tablesListView.Height = 220;
            tablesListView.View = View.Details;
            tablesListView.FullRowSelect = true;
            //tablesListView.BackColor=Color.DarkCyan;

            tablesListView.Columns.Add("Table Number", -2, HorizontalAlignment.Left);
            tablesListView.Columns.Add("Table Status", -2, HorizontalAlignment.Left);
            List<Table> tables = tableService.GetTables();

            //for (int i = 0; i < tables.Count; i++)
            //{
            //    string[] items = { tables[i].tableID.ToString(), tables[i].occupied.ToString() };
            //}
            //tablesListView.Items.Clear();
            foreach (Table table in tables)
            {
                ListViewItem entryItem = tablesListView.Items.Add(table.tableID.ToString());

                if (table.occupied == true)
                {
                    entryItem.SubItems.Add("Reserved");
                }
                else
                {
                    entryItem.SubItems.Add("Un-Reserved");
                }
            }
            return tablesListView;
        }

        private Control CreateChnageTableStatusBtn()
        {
            Button changeTableStatusBtn = new Button();
            changeTableStatusBtn.Text = "Change Status";
            changeTableStatusBtn.Width = tablesViewBtn.Width;
            changeTableStatusBtn.Height = tablesViewBtn.Height;
            changeTableStatusBtn.Top = orderViewPanel.Bottom - 200;
            changeTableStatusBtn.Left = orderViewPanel.Right - 460;

            changeTableStatusBtn.Click += new EventHandler(changeTableStatusBtn_Click);

            return changeTableStatusBtn;
        }

        private void changeTableStatusBtn_Click(object sender, EventArgs e)
        {
            bool occuoied;
            int tableID = Convert.ToInt32(tablesListView.SelectedItems[0].Text);

            if (tablesListView.SelectedItems[0].SubItems[1].Text == "Reserved")
            {
                occuoied = false;
            }
            else
            {
                occuoied = true;
            }

            tableService.ChangeTableStatus(new Table(tableID, occuoied));
            orderViewPanel.Controls.Clear();
            orderViewPanel.Controls.Add(ShowTables());

        }

        private void logoffLink_Click(object sender, EventArgs e)
        {
           
           
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Close();
        }
    }
}
