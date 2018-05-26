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
        OrderItemsDAO orderItem = new OrderItemsDAO();


        public Control ShowOrderItems(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();

            orders = orderItem.getOrders(ID);

            // Making a list and editing its format 
            ListView ordersListView = new ListView();
            ordersListView.Height = 250;
            ordersListView.Width = 450;
            ordersListView.View = View.Details;
            ordersListView.FullRowSelect = true;
            ordersListView.CheckBoxes = true;

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
            headerFourth.Text = "Ready";
            headerFourth.Width = 75;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Served";
            headerFifth.Width = 75;

            // adding colums to the list
            ordersListView.Columns.Add(headerFirst);
            ordersListView.Columns.Add(headerSecond);
            ordersListView.Columns.Add(headerThird);
            ordersListView.Columns.Add(headerFourth);
            ordersListView.Columns.Add(headerFifth);

            // storing data into the list
            foreach (OrderItems item in orders)
            {
                ListViewItem entryListItem = ordersListView.Items.Add(item.orderID.ToString());
                entryListItem.SubItems.Add(item.tableID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                if (item.isReady == false)
                {
                    entryListItem.SubItems.Add("Not Ready");
                }
                else
                {
                    entryListItem.SubItems.Add("Ready");
                }
                if (item.isServed == false)
                {

                    if (item.isReady == true)
                    {
                        entryListItem.SubItems.Add("Needs to be served!");
                    }
                    else
                    {

                        entryListItem.SubItems.Add("Not Served");
                    }
                }
                else
                {
                    entryListItem.SubItems.Add("Served");
                }

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
            orderItem.InsertOrderItems(orderItemsList, order);

        }


    }
}
