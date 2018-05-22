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
        public static Control ShowOrders(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();

            orders = OrderItemsDAO.getOrders(ID);

            // Making a list and editing its format 
            ListView ordersListView = new ListView();
            ordersListView.Height = 250;
            ordersListView.Width = 700;
            ordersListView.View = View.Details;
            ordersListView.FullRowSelect = true;

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
            headerSecond.Width = 75;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Name";
            headerThird.Width = 250;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Is Ready?";
            headerFourth.Width = 140;

            headerFifth.TextAlign = HorizontalAlignment.Left;
            headerFifth.Text = "Is Served?";
            headerFifth.Width = 140;

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
                    entryListItem.SubItems.Add("Not Served");
                }
                else
                {
                    entryListItem.SubItems.Add("Served");
                }
                
            }

            // return a list view 
            return ordersListView;
        }

       
    }
}
