using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class MenuItem
    {
        public int menuItemID { get; set; }
        public string itemName { get; set; }
        public float price { get; set; }
        public float vatPercentage { get; set; }
        public int amountOnStock { get; set; }
        public bool barOrKitchen { get; set; } // true is kitchen while false is bar

        public MenuItem(int menuItemID, string itemName, float price, float vatPercentage,
            int amountOnStock, bool barOrKitchen)
        {
            this.menuItemID = menuItemID;
            this.itemName = itemName;
            this.price = price;
            this.vatPercentage = vatPercentage;
            this.amountOnStock = amountOnStock;
            this.barOrKitchen = barOrKitchen;
        }


    }



}
