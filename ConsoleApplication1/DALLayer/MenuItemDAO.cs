using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class MenuItemDAO : BaseDAO
    {
        public List<MenuItem> GetMenuItems()
        {
            SqlConnection connection = OpeConnection();

            string sqlQuery = @"SELECT * FROM MenuItems";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<MenuItem> menuItems = new List<MenuItem>();


            while (reader.Read())
            {

                int menuItemID = Convert.ToInt32(reader["MenuItemId"]);
                string itemName = Convert.ToString(reader["ItemName"]);
                float price = Convert.ToSingle(reader["Price"]);
                float vatPercentage = Convert.ToSingle(reader["VAT"]);
                int amountOnStock = Convert.ToInt32(reader["AmountOnStock"]);
                bool barOrKitchen = Convert.ToBoolean(reader["BarOrKitchen"]);

                menuItems.Add(
                    new MenuItem(menuItemID, itemName, price, vatPercentage, amountOnStock, barOrKitchen));
            }
            reader.Close();
            CloseConnection(connection);

            return menuItems;
        }


    }
}
