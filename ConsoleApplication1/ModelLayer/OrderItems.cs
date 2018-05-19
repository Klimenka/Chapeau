using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class OrderItems
    {
        public int orderItemID { get; set; }
        public int orderID { get; set; }
        public int menuItemID { get; set; }
        public DateTime dateTaken { get; set; }
        public int amount { get; set; }
        public bool isReady { get; set; }
        public DateTime dateReady { get; set; }
        public string comment { get; set; }

        public OrderItems(int orderItemID, int orderID, int menuItemID, DateTime dateTaken, int amount, 
            bool isReady, DateTime dateReady)
        {
            this.orderItemID = orderItemID;
            this.orderID = orderID;
            this.menuItemID = menuItemID;
            this.dateTaken = dateTaken;
            this.amount = amount;
            this.isReady = isReady;
            this.dateReady = dateReady;
        }

    }
}
