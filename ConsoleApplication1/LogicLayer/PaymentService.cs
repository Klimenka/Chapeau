using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;
using ChapeauModel;

namespace ChapeauLogic
{
    public class PaymentService
    {
        private PaymentDAO paymentDAO = new PaymentDAO();
        private float VAT;

        public List<MenuItem> menuItems(int orderID)
        {
            List<MenuItem> menuItems = paymentDAO.MenuItems(orderID);

            for (int i = 0; i < menuItems.Count; i++)
            {
                VAT = (menuItems[i].price * menuItems[i].item.amount) * menuItems[i].vatPercentage;
                menuItems[i].price = (menuItems[i].price * menuItems[i].item.amount) + VAT;

                menuItems[i].totalPrice += menuItems[i].price;
                VAT = 0;
            }


            return menuItems;
        }

        //takes the information from the UI to the Database
        public void StorePayment(Payment payment, int tableID)
        {
            paymentDAO.StorePayment(payment, tableID);
        }




    }
}
