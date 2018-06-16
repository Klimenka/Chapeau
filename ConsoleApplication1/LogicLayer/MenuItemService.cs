using ChapeauDAL;
using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChapeauLogic
{
    public class MenuItemService
    {
        private MenuItemDAO menuItemDAO = new MenuItemDAO();
       

        public List<MenuItem> GetMenuItems()
        {
            //get all items from DB
            return menuItemDAO.GetAll();

        }

        
    }
}
