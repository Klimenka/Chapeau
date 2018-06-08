using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Order
    {
        public int orderID { get; set; }
        public int employeeID { get; set; }
        public int tableID { get; set; }
        public string feedback { get; set; }
        public List<OrderItems> items = new List<OrderItems>();

        public Order(int orderID, int employeeID, int tableID)
        {
            this.orderID = orderID;
            this.employeeID = employeeID;
            this.tableID = tableID;
        }
        public Order()
        {

        }

    }
}
