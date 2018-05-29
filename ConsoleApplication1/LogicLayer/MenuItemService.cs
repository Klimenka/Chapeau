﻿using ChapeauDAL;
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
       

        public List<ChapeauModel.MenuItem> GetMenuItems()
        {
            //get all items from DB
            return menuItemDAO.GetAll();

        }

        
    }
}
