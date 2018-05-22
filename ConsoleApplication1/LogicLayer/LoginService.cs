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

        public static Employess CheckCredentials(Login user)
        {
            if (string.IsNullOrEmpty(user.loginName) || string.IsNullOrEmpty(user.password))
            {
                throw new Exception("Please enter your username/password");
            }
            {
                
            }
            Employess employeee = null;
            try
            {
                employeee = LoginDAO.CheckCredentials(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return employeee;
        }






    }
}
