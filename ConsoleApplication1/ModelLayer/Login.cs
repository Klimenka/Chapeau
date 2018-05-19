using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    class Login
    {
        public string loginName { get; set; }
        public string password { get; set; }
        public int employeeID { get; set; }

        public Login(string loginName, string password, int employeeID)
        {
            this.loginName = loginName;
            this.password = password;
            this.employeeID = employeeID;
        }

    }
}
