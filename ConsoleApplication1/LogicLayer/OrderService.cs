using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauLogic
{
    public class OrderService
    {
        OrderDAO order = new OrderDAO();
        
        //sending to DB request for the creation a new order and returning an object Order
        public Order NewOrder(int EmpId, int tableID)
        {
            
            return order.NewOrder(EmpId, tableID);
           
        }

        public int GetOrderID(int tableIdExistedOrder)
        {
            return order.GetOrderIdDB(tableIdExistedOrder);
        }



    }
}
