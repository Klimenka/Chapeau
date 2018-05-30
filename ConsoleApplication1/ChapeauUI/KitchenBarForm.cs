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
    public partial class KitchenBarForm : Form
    {
        public KitchenBarForm()
        {
            InitializeComponent();
            //listBox1.Items.Add("Order 1");
            //listBox1.Items.Add("Order 2");
            //listBox1.Items.Add("Order 3");
           // listBox1.Items.Add("Order 4");
          //  listBox1.Items.Add("Order 5");
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
        private void KitchenBarForm_Load(object sender, EventArgs e)
        {

        }

      
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



        private void orderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
