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
           
        }

        private void createNew_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            Label table = new Label();
            table.Text = "Table: ";
            table.AutoSize = true;
            table.Location = new Point(550, 25);
            panel1.Controls.Add(table);

            ComboBox table_choice = new ComboBox();
            table_choice.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"});
            table.AutoSize = true;
            table_choice.Location = new Point(600, 21);
            panel1.Controls.Add(table_choice);

            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
