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

namespace ChapeauUI
{
    public partial class orderForm : Form
    {
        public orderForm(int ID)
        {
            InitializeComponent();
            Shown += orderForm_Load;
            employeeID.Text = ID.ToString();
        }
        
        private void orderForm_Load(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            panel1.Controls.Add(OrderService.ShowOrders(int.Parse(employeeID.Text)));

            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(550, 45);
            panel1.Controls.Add(table);

            ComboBox table_choice = new ComboBox();
            table_choice.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" });
            table.AutoSize = true;
            table_choice.Location = new Point(600, 45);
            panel1.Controls.Add(table_choice);

            Label find_order = new Label();
            find_order.Text = "Find the order by table number: ";
            find_order.AutoSize = true;
            find_order.Location = new Point(550, 20);
            panel1.Controls.Add(find_order);

            Button find_order_by_table = new Button();
            find_order_by_table.Text = "Open the order";
            find_order_by_table.Width = 166;
            find_order_by_table.Height = 47;
            find_order_by_table.Location = new Point(550, 75);
            panel1.Controls.Add(find_order_by_table);

            Button served = new Button();
            served.Text = "Served";
            served.Width = 166;
            served.Height = 47;
            served.Location = new Point(285, 265);
            panel1.Controls.Add(served);
            served.Click += new EventHandler(served_clicked);
        }

        private void served_clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void createNew_Click(object sender, EventArgs e)
        {
            //creating of a new order in DB
            string table_text = ShowChooseTable();
            int tableID;
            tableID = int.Parse(table_text);
            Order order = new Order();
            order = OrderService.NewOrder(int.Parse(employeeID.Text), tableID);

            //clear space for new data
            panel1.Controls.Clear();

            //saving data on the panel
            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(50, 25);
            panel1.Controls.Add(table);

            Label chosen_table = new Label();
            chosen_table.Text = order.tableID.ToString();
            chosen_table.AutoSize = true;
            chosen_table.Location = new Point(130, 25);
            panel1.Controls.Add(chosen_table);

            Label order_text = new Label();
            order_text.Text = "Order: ";
            order_text.AutoSize = true;
            order_text.Location = new Point(210, 25);
            panel1.Controls.Add(order_text);

            Label orderid = new Label();
            orderid.Text = order.employeeID.ToString();
            orderid.AutoSize = true;
            orderid.Location = new Point(290, 25);
            panel1.Controls.Add(orderid);


        }

        //new window for a table choice 
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
            confirmation.Click += (sender, e) => { text = table_choice.SelectedItem.ToString(); message.Close();};
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
    }
}
