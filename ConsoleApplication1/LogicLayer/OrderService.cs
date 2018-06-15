using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChapeauLogic
{
    public class OrderService
    {
        OrderDAO order = new OrderDAO();

        public float totalPrice;
        public float subtotalPrice;
        public float VAT_06;
        public float VAT_21;

        OrderDAO orderDAO = new OrderDAO();
        MenuItemDAO menuItemDAO = new MenuItemDAO();

        public List<OrderItems> OrderItemsExistedLogic(Order existedOrder)
        {
            totalPrice = (float)0.00;
            subtotalPrice = (float)0.00;
            VAT_06 = (float)0.00;
            VAT_21 = (float)0.00;

            List<MenuItem> menuItems = new List<MenuItem>();
            List<OrderItems> orderItems = new List<OrderItems>();
            menuItems = menuItemDAO.GetAll();

            orderItems = orderDAO.GetExistedOrderItems(existedOrder);

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

        public bool CheckIfExistedOrder(int orderID)
        {
            return orderDAO.CheckIfExistedOrderDB(orderID);
        }

        public List<Order> GetOrderItems(int ID)
        {
            return orderDAO.getOrders(ID);

        }
        //get kitchne order from DB
        public List<Order> GetKitchenItems()
        {
            return orderDAO.getOrderItemsKitchen();
        }
        //get bar order from DB
        public List<Order> GetBarItems()
        {
            return orderDAO.getOrderItemsBar();

        }

        public void AddNewOrderItemsToDB(List<OrderItems> orderItemsList, Order order)
        {
            orderDAO.InsertOrderItems(orderItemsList, order);

        }


        public void CheckAsServed(int[] checkedItems)
        {
            orderDAO.CheckAsServedItems(checkedItems);
        }

        public void CheckAsReady(int[] checkedItems)
        {
            orderDAO.CheckAsReadyItems(checkedItems);
        }

        //sending to DB request for the creation a new order and returning an object Order
        public Order NewOrder(int EmpId, int tableID)
        {
            
            return order.NewOrder(EmpId, tableID);
           
        }

        public int GetOrderID(int tableIdExistedOrder)
        {
            return order.GetOrderIdDB(tableIdExistedOrder);
        }

        public void DeleteOrder(Order delete_order)
        {
            order.DeleteOrderDB(delete_order);

        }


    }
}
