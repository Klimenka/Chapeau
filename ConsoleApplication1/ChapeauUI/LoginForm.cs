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
    
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private LoginService login = new LoginService();

        // login 
        private void LoginBtn_click(object sender, EventArgs e)
        {
            Employess employee = null;
            string userName = nameTxtBox.Text;
            string password = passwordTxtBox.Text;

            try
            {
                if (nameTxtBox.Text == "" || passwordTxtBox.Text == "")
                {
                    // throw an exception if one of the text boxes is empty
                    throw new Exception("Please enter your username/password");
                }

                // pass the entered data to the logic/DB to check if it matches
                employee = login.CheckCredentials(new Login(userName, password));

                if (employee == null)
                {
                    // throw an exception if there is no matching with the DB
                    throw new Exception("Please check your credentials");
                }

                if (employee.positionID == Position.Waiter) // show the order form if the user is a Waiter
                {
                    //add Employee info to the OrderFrom in order to know who logged in
                    orderForm orderForm = new orderForm(employee, this);
                    orderForm.Show();
                    this.Hide(); // hide the login from
                }
                else                
                {
                    // show the kitchen/bar form if the user is a Chef/Barman
                    KitchenBarForm kitchenForm = new KitchenBarForm(employee, this);
                    kitchenForm.Show();
                    this.Hide(); // hide the login from
                }
            }
            catch (Exception exception)
            {
                // show the message
                MessageBox.Show(exception.Message,"Warnning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit(); // exit the whole app
        }


    }
}
