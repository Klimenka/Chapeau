using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using ModelLayer;

namespace ChapeauDAL
{
    public class MenuItemDAO : BaseDAO
    {

        public List<MenuItem> GetAll()
        {
            SqlConnection connection = OpeConnection();

            string sqlQuery = @"SELECT MenuItemId, ItemName, Price,VAT,AmountOnStock, BarOrKitchen, CategoryId
                                FROM MenuItems";
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
                Category category = (Category)reader["CategoryId"];
                menuItems.Add(
                    new MenuItem(menuItemID, itemName, price, vatPercentage, amountOnStock, barOrKitchen, category));
            }
            reader.Close();
            CloseConnection(connection);

            return menuItems;
        }


    }
}
