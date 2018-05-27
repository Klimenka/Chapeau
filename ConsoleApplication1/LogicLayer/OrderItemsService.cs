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
        public float VAT;

        OrderItemsDAO orderItemDAO = new OrderItemsDAO();
        MenuItemDAO menuItemDAO = new MenuItemDAO();

        public ListView ShowOrderItems(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();

            orders = orderItemDAO.getOrders(ID);

            // Making a list and editing its format 
            ListView ordersListView = new ListView();
            ordersListView.Height = 250;
            ordersListView.Width = 500;
            ordersListView.View = View.Details;
            ordersListView.FullRowSelect = true;
            ordersListView.CheckBoxes = true;
            ordersListView.MultiSelect = true;

            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "OrderID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 75;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Table";
            headerSecond.Width = 45;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Name";
            headerThird.Width = 150;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Amount";
            headerFourth.Width = 70;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Task";
            headerFifth.Width = 150;


            // adding colums to the list
            ordersListView.Columns.Add(headerFirst);
            ordersListView.Columns.Add(headerSecond);
            ordersListView.Columns.Add(headerThird);
            ordersListView.Columns.Add(headerFourth);
            ordersListView.Columns.Add(headerFifth);

            // storing data into the list
            foreach (OrderItems item in orders)
            {
                if (item.isServed == false && item.isReady == true)
                {
                    ListViewItem entryListItem = ordersListView.Items.Add(item.orderItemID.ToString());
                    entryListItem.SubItems.Add(item.tableID.ToString());
                    entryListItem.SubItems.Add(item.itemName);
                    entryListItem.SubItems.Add(item.amount.ToString());
                    entryListItem.SubItems.Add("Needs to be served");

                }
                else
                    continue;

            }

            // return a list view 
            return ordersListView;
        }

        public ListView ShowIncompleteOrder(List<OrderItems> items)
        {
            ListView itemsListView = new ListView();
            itemsListView.Height = 230;
            itemsListView.Width = 350;
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;
            itemsListView.Left = 400;



            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 30;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 150;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Amount";
            headerThird.Width = 40;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Comment";
            headerFourth.Width = 100;

            // adding colums to the list
            itemsListView.Columns.Add(headerFirst);
            itemsListView.Columns.Add(headerSecond);
            itemsListView.Columns.Add(headerThird);
            itemsListView.Columns.Add(headerFourth);


            // storing data into the list
            foreach (OrderItems item in items)
            {
                ListViewItem entryListItem = new ListViewItem();
                entryListItem = itemsListView.Items.Add(item.menuItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.amount.ToString());
                entryListItem.SubItems.Add(item.comment);

            }

            // return a list view 
            return itemsListView;

        }

        public void AddNewOrderItemsToDB(List<OrderItems> orderItemsList, Order order)
        {
            orderItemDAO.InsertOrderItems(orderItemsList, order);

        }

        public ListView ShowOrderItemsExisted(Order existedOrder)
        {
            float price;
            float priceForItem;
            totalPrice = (float)0.00;
            subtotalPrice = (float)0.00;
            VAT = (float)0.00;
            List<ChapeauModel.MenuItem> menuItems = new List<ChapeauModel.MenuItem>();
            List<OrderItems> orderItems = new List<OrderItems>();
            menuItems = menuItemDAO.GetAll();

            orderItems = orderItemDAO.GetExistedOrderItems(existedOrder);

            ListView itemsListView = new ListView();
            itemsListView.Height = 200;
            itemsListView.Width = 700;
            itemsListView.View = View.Details;
            itemsListView.FullRowSelect = true;



            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            ColumnHeader headerFifth = new ColumnHeader();
            ColumnHeader headerSixth = new ColumnHeader();
            ColumnHeader headerSeventh = new ColumnHeader();


            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 60;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 250;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Price";
            headerThird.Width = 60;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Amount";
            headerFourth.Width = 50;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "TotalPrice";
            headerFifth.Width = 60;

            headerSixth.TextAlign = HorizontalAlignment.Left;
            headerSixth.Text = "Comment";
            headerSixth.Width = 80;

            headerSeventh.TextAlign = HorizontalAlignment.Left;
            headerSeventh.Text = "Is served?";
            headerSeventh.Width = 75;

            // adding colums to the list
            itemsListView.Columns.Add(headerFirst);
            itemsListView.Columns.Add(headerSecond);
            itemsListView.Columns.Add(headerThird);
            itemsListView.Columns.Add(headerFourth);
            itemsListView.Columns.Add(headerFifth);
            itemsListView.Columns.Add(headerSixth);
            itemsListView.Columns.Add(headerSeventh);

            // storing data into the list
            foreach (OrderItems item in orderItems)
            {
                ListViewItem entryListItem = new ListViewItem();
                entryListItem = itemsListView.Items.Add(item.orderItemID.ToString());
                entryListItem.SubItems.Add(menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).itemName);
                //get price
                price = menuItems.First(menuItem => menuItem.menuItemID == item.menuItemID).price;

                //add to Total
                totalPrice = totalPrice + price;

                //add to listControl
                entryListItem.SubItems.Add(price.ToString("0.00"));
                entryListItem.SubItems.Add(item.amount.ToString());

                //calculate amount*price
                priceForItem = item.amount * price;
                entryListItem.SubItems.Add(priceForItem.ToString("0.00"));
                entryListItem.SubItems.Add(item.comment);
                if (item.isServed == true)
                {
                    entryListItem.SubItems.Add("Yes");
                }
                else
                {
                    entryListItem.SubItems.Add("No");
                }

            }

            // return a list view 
            return itemsListView;

        }

        public void CheckAsServed(int[] checkedItems)
        {
            orderItemDAO.CheckAsServedItems(checkedItems);
        }
    }
}
