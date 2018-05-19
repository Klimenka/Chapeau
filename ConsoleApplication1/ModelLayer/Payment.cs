using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Payment
    {
        public int paymentID { get; set; }
        public int orderID { get; set; }
        public DateTime date { get; set; }
        public float tip { get; set; }
        public int employeeID { get; set; }
        public PaymentMethod paymentMethod { get; set; }

        public Payment(int paymentID, int orderID, DateTime date, float tip, int employeeID,
            PaymentMethod paymentMethod)
        {
            this.paymentID = paymentID;
            this.orderID = orderID;
            this.date = date;
            this.tip = tip;
            this.employeeID = employeeID;
            this.paymentMethod = paymentMethod;
        }

    }
}
