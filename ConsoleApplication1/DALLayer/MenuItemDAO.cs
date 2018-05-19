using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class MenuItemDAO
    {
        public List<MenuItem> GetMenuItems()
        {
            SqlConnection connection = SqlConn.OpeConnection();

            string sqlQuery = @"SELECT * FROM MenuItems";
            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = command.ExecuteReader();
            List<MenuItem> menuItems = new List<MenuItem>();

            while (reader.Read())
            {
                MenuItem menuItem = new MenuItem();

                menuItem.menuItemID = (int)reader["MenuItemId"];
                menuItem.itemName = (string) reader["ItemName"];
                menuItems.Add(menuItem);
            }
            reader.Close();
            SqlConn.CloseConnection(connection);
            


            return menuItems;
        }


    }
}
