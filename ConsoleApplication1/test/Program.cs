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

            List<ChapeauModel.MenuItem> menu= menuItemDao.GetMenuItems();

            foreach (ChapeauModel.MenuItem menus in menu)
            {
                Console.WriteLine(menus.itemName);
            }

            Console.ReadLine();
        }
    }
}
