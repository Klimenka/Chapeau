using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Employess
    {
        public int employeeID { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public Position positionID { get; set; }

        public Employess(int employeeID, string name, string lastName, Position positionID)
        {
            this.employeeID = employeeID;
            this.name = name;
            this.lastName = lastName;
            this.positionID = positionID;
        }

    }



}
