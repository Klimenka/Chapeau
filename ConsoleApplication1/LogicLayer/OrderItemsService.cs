using ChapeauDAL;
using ChapeauLogic;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChapeauLogic
{
    public class OrderItemsService
    {
        public float totalPrice;
        public float subtotalPrice;
        public float VAT_06;
        public float VAT_21;

        OrderItemsDAO orderItemDAO = new OrderItemsDAO();
        MenuItemDAO menuItemDAO = new MenuItemDAO();

        public List<OrderItems> OrderItemsExistedLogic(Order existedOrder)
        {
            totalPrice = (float)0.00;
            subtotalPrice = (float)0.00;
            VAT_06 = (float)0.00;
            VAT_21 = (float)0.00;

            List<ChapeauModel.MenuItem> menuItems = new List<ChapeauModel.MenuItem>();
            List<OrderItems> orderItems = new List<OrderItems>();
            menuItems = menuItemDAO.GetAll();

            orderItems = orderItemDAO.GetExistedOrderItems(existedOrder);

            foreach (OrderItems item in orderItems)
            {
                //get price
                subtotalPrice = subtotalPrice + (menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).price * item.amount);

                if (menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).vatPercentage.ToString("0.00") == "0.06")
                {
                    VAT_06 = (float)(VAT_06 + (menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).price * 0.06 * item.amount));
                }
                else
                {
                    VAT_21 = (float)(VAT_21 + (menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).price * 0.21 * item.amount));
                }

            }

            totalPrice = subtotalPrice + VAT_06 + VAT_21;

            return orderItems;
        }

        public List<OrderItems> GetOrderItems(int ID)
        {
            return orderItemDAO.getOrders(ID);

        }

        public List<OrderItems> GetKitchenItems()
        {
            return orderItemDAO.getOrderItemsKitchen();
        }

        public List<OrderItems> GetBarItems()
        {
            return orderItemDAO.getOrderItemsBar();

        }

        public void AddNewOrderItemsToDB(List<OrderItems> orderItemsList, Order order)
        {
            orderItemDAO.InsertOrderItems(orderItemsList, order);

        }

        
        public void CheckAsServed(int[] checkedItems)
        {
            orderItemDAO.CheckAsServedItems(checkedItems);
        }
    }
}
