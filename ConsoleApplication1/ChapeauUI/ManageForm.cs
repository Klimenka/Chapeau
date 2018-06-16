using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChapeauLogic;
using ChapeauModel;

namespace ChapeauUI
{
    public partial class ManageForm : Form
    {
        public ManageForm()
        {
            InitializeComponent();
            cboxPosition.SelectedIndex = 0;
        }

        private LoginService loginService = new LoginService();
        private Login login = new Login();
        private Employess employee = new Employess();

        private void ManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // if empty show an error messge
            if (txtBoxFirstN.Text == "" || txtBoxLastN.Text == "" || cboxPosition.Text == "" || txtBoxUserName.Text == ""
                || txtBoxPassword.Text == "" || txtBoxRePasswrd.Text == "")
            {
                MessageBox.Show(@"Please fill in all the fields!", @"Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

            employee.name = txtBoxFirstN.Text;
            employee.lastName = txtBoxLastN.Text;
            employee.position = (Position)(cboxPosition.SelectedIndex + 1);

            login.loginName = txtBoxUserName.Text;
            login.password = txtBoxPassword.Text;

            // pass data entered to the logic/DB
            loginService.RegisterEmployee(employee, login);

            // show a confirmation message
            MessageBox.Show(@"Registration has been successfully completed", @"Registeration"
                , MessageBoxButtons.OK, MessageBoxIcon.Information);

            // clear data in text boxes
            txtBoxFirstN.Text = "";
            txtBoxLastN.Text = "";
            txtBoxUserName.Text = "";
            txtBoxPassword.Text = "";
            txtBoxRePasswrd.Text = "";

        }


    }
}
