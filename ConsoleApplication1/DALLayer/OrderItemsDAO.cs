using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderItemsDAO : BaseDAO
    {
        public static List<OrderItems> getOrders(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();
            SqlConnection connection = SqlConn.OpeConnection();


            // write a sql query 
            string SQLquery = @"SELECT a.OrderId, a.TableId, b.ItemName, c.isReady, c.IsServed from Orders as a
                                INNER JOIN OrderItems as c ON c.OrderId = a.OrderId
                                INNER JOIN MenuItems as b ON c.MenuItemId = b.MenuItemId
                                WHERE a.EmployeeId = @ID ";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                OrderItems order = new OrderItems();
                order.orderID = (int)reader["OrderId"];
                order.tableID = (int)reader["TableId"];
                order.itemName = Convert.ToString(reader["ItemName"]);
                order.isReady = (bool)reader["isReady"];
                order.isServed = (bool)reader["IsServed"];
                orders.Add(order);
            }

            // close all connections
            reader.Close();
            SqlConn.CloseConnection(connection);

            return orders;
        }
    }
}
