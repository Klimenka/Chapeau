using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItems:Order
    {
        public int orderItemID { get; set; }
        public int menuItemID { get; set; }
        public string itemName { get; set; }
        public int amount { get; set; }
        public bool isReady { get; set; }
        public bool isServed { get; set; }
        

        private DateTime dateTaken { get; set; }
        private DateTime dateReady { get; set; }

        public string comment { get; set; }

        public OrderItems(int orderID, int employeeID, int tableID, int orderItemID, int menuItemID, DateTime dateTaken, int amount, 
            bool isReady, DateTime dateReady):base(orderID, employeeID, tableID)
        {
            this.orderItemID = orderItemID;
            this.menuItemID = menuItemID;
            this.dateTaken = dateTaken;
            this.amount = amount;
            this.isReady = isReady;
            this.dateReady = dateReady;
        }
        public OrderItems()
        {

        }
    }
}
