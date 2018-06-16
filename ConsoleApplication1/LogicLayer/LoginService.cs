using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class LoginService
    {
        private LoginDAO loginDAO = new LoginDAO();
         

        public Employess CheckCredentials(Login user)
        {
            Employess employeee = loginDAO.CheckCredentials(user);

            return employeee;
        }

        public void RegisterEmployee(Employess employee, Login loginInfo)
        {
            loginDAO.RegisterEmployee(employee, loginInfo);
        }

    }



}
