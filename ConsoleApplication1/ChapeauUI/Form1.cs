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
using ChapeauLogic;

namespace ChapeauUI
{
    
    public partial class LoginForm : Form
    {
        LoginService loginService = new LoginService();
        public LoginForm()
        {
            InitializeComponent();
        }
        private LoginService login = new LoginService();

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void LoginBtn_click(object sender, EventArgs e)
        {
            Employess employee = null;
            string userName = nameTxtBox.Text;
            string password = passwordTxtBox.Text;

            try
            {
                if (nameTxtBox.Text == "" || passwordTxtBox.Text == "")
                {
                    throw new Exception("Please enter your username/password");
                }

                employee = login.CheckCredentials(new Login(userName, password));

                if (employee == null)
                {
                    throw new Exception("Please check your credentials");
                }

                if (employee.positionID == Position.Waiter)
                {
                    //add EmployeeID for the OrderFrom
                    orderForm orderForm = new orderForm(employee.employeeID);
                    orderForm.Show();
                    this.Hide();
                }
                else if (employee.positionID == Position.Chef)
                {
                    KitchenBarForm kitchenForm = new KitchenBarForm();
                    kitchenForm.Show();
                    this.Hide();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,"Warnning",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            //if (MessageBox.Show("Are you sure you want to close Chapeau Application?", "CLose Chapeau Application",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.No)
            //{
                
            //    e.Cancel = true;
            //}
            Application.Exit();

        }


    }
}
