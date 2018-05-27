using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;
namespace LogicLayer
{
    public class LoginService
    {
        private LoginDAO login = new LoginDAO();

        public Employess CheckCredentials(Login user)
        {
            Employess employeee = login.CheckCredentials(user);

            return employeee;
        }

    }



}
