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
using LogicLayer;

namespace ChapeauUI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_click(object sender, EventArgs e)
        {
            string userName = nameTxtBox.Text;
            string password = passwordTxtBox.Text;

            try
            {
                Employess employee = LoginService.CheckCredentials(new Login(userName, password, 1));

                if (employee.positionID == Position.Waiter)
                {
                    orderForm orderForm = new orderForm(); 
                    orderForm.Show();
                    this.Close();

                }
                else if (employee.positionID == Position.Chef)
                {
                    KitchenBarForm kitchenForm = new KitchenBarForm();
                    kitchenForm.Show();
                    this.Close();
                }
     
            }
            catch (Exception exception)
            {
                MessageBox.Show("Please check your credentials");
            }
   
        }



    }


}
