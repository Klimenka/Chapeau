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
        public MenuItem menuItem = new MenuItem();

        public static Control ShowMenuItems()
        {
            return MenuItemDAO.GetAll();
        }
    }
}
