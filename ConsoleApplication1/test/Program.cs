using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauDAL;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuItemDAO menuItemDao= new MenuItemDAO();

            //List<ChapeauModel.MenuItem> menu= menuItemDao.GetMenuItems();
           
            foreach (ChapeauModel.MenuItem menus in menuItemDao.GetMenuItems())
            {
                Console.WriteLine(menus.menuItemID +" "+ menus.itemName + " " + menus.price + " " + menus.vatPercentage + " " +
                                  menus.amountOnStock + " " + menus.barOrKitchen);
            }

            Console.ReadLine();
        }
    }
}
