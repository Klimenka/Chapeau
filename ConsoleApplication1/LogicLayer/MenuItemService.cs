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
    public class MenuItemService
    {
        public MenuItemDAO menuItemDAO = new MenuItemDAO();
        List<ChapeauModel.MenuItem> menuItems = new List<ChapeauModel.MenuItem>();

        public ListView ShowMenuItems()
        {
            //List<ChapeauModel.MenuItem> menuItems = new List<ChapeauModel.MenuItem>();
            menuItems = menuItemDAO.GetAll();
            

            // Making a list and editing its format 
            ListView MenuItemsListView = new ListView();
            MenuItemsListView.Height = 230;
            MenuItemsListView.Width = 365;
            MenuItemsListView.View = View.Details;
            MenuItemsListView.FullRowSelect = true;
            //MenuItemsListView.CheckBoxes = true;
            MenuItemsListView.HideSelection = false;
            MenuItemsListView.Select();


            ColumnHeader headerFirst = new ColumnHeader();
            ColumnHeader headerSecond = new ColumnHeader();
            ColumnHeader headerThird = new ColumnHeader();
            ColumnHeader headerFourth = new ColumnHeader();
            //ColumnHeader headerFifth = new ColumnHeader();

            // Set the text, alignment and width for each column header.
            headerFirst.Text = "ID";
            headerFirst.TextAlign = HorizontalAlignment.Left;
            headerFirst.Width = 45;

            headerSecond.TextAlign = HorizontalAlignment.Left;
            headerSecond.Text = "Name";
            headerSecond.Width = 170;

            headerThird.TextAlign = HorizontalAlignment.Left;
            headerThird.Text = "Stock";
            headerThird.Width = 50;

            headerFourth.TextAlign = HorizontalAlignment.Left;
            headerFourth.Text = "Bar Or Kitchen";
            headerFourth.Width = 75;

            //headerFifth.TextAlign = HorizontalAlignment.Left;
            //headerFifth.Text = "Category";
            //headerFifth.Width = 75;

            // adding colums to the list
            MenuItemsListView.Columns.Add(headerFirst);
            MenuItemsListView.Columns.Add(headerSecond);
            MenuItemsListView.Columns.Add(headerThird);
            MenuItemsListView.Columns.Add(headerFourth);
            //MenuItemsListView.Columns.Add(headerFifth);

            // storing data into the list
            foreach (ChapeauModel.MenuItem item in menuItems)
            {

                ListViewItem entryListItem = new ListViewItem();
                entryListItem.Tag = item;
                entryListItem = MenuItemsListView.Items.Add(item.menuItemID.ToString());
                entryListItem.SubItems.Add(item.itemName);
                entryListItem.SubItems.Add(item.amountOnStock.ToString());
                if (item.barOrKitchen == false)
                {
                    entryListItem.SubItems.Add("Bar");
                }
                else
                {
                    entryListItem.SubItems.Add("Kitchen");
                }
               // entryListItem.SubItems.Add(item.category.ToString());
 
            }

            // return a list view 
            return MenuItemsListView;
            

        }

        public string FindItemNameByIndex(int menuItemIndex)
        {
            string itemName = "";
            List<ChapeauModel.MenuItem> menuItems = new List<ChapeauModel.MenuItem>();
            menuItems = menuItemDAO.GetAll();

            itemName = menuItems[menuItemIndex].itemName;

            return itemName;
        }
    }
}
