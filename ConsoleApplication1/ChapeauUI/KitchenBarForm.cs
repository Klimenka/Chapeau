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

namespace ChapeauUI
{
    public partial class KitchenBarForm : Form
    {
       

        public KitchenBarForm(string employeeName, Position employeePosition)
        {
            InitializeComponent();

            // show the name of the user who logged in
            empNameLbl.Text = "[" + employeeName + " <" + employeePosition + ">" + "]";

            //listBox1.Items.Add("Order 1");
            //listBox1.Items.Add("Order 2");
            //listBox1.Items.Add("Order 3");
            //listBox1.Items.Add("Order 4");
            //listBox1.Items.Add("Order 5");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listBox1.SelectedIndex == 1)
            //{
            //    LoadListBox();
            //}
        }


        //private void LoadListBox()
        //{
        //    listBox2.Items.Clear();
        //    listBox2.Items.Add("DOubke Burger");
        //    listBox2.Items.Add("Pizza");
        //    listBox2.Items.Add("Burger");
        //    listBox2.Items.Add("Coak");
        //    listBox2.Items.Add("Pepsi");
        //    listBox2.Items.Add("Wine");
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

    }
}
