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
        public void InsertOrderItems(List<OrderItems> orderItemsList, Order order)
        {
            int amountOnStock = 0;
            int newAmountOnStock;

            SqlConnection connection = OpeConnection();

            for (int i = 0; i < orderItemsList.Count; i++)

            {
                if (orderItemsList[i].comment == "")
                {
                    // write a sql query 
                    string SQLquery = @"INSERT into OrderItems (OrderId, MenuItemId, DateTaken, Amount, IsReady, IsServed)
                                VALUES (@OrderId, @MenuItemId, GETDATE(), @Amount, 0, 0)";

                    // execute the sql query
                    SqlCommand command = new SqlCommand(SQLquery, connection);
                    command.Parameters.AddWithValue("@OrderId", order.orderID);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);
                    command.Parameters.AddWithValue("@Amount", orderItemsList[i].amount);

                    command.ExecuteNonQuery();

                    //getting an amount on the stock of this item
                    string SQLquery1 = @"SELECT AmountOnStock FROM MenuItems
                                         WHERE MenuItemId = @MenuItemId";
                    command = new SqlCommand(SQLquery1, connection);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        amountOnStock = int.Parse(reader["AmountOnStock"].ToString());
                    }

                    reader.Close();

                    //getting a new amount on the stock
                    newAmountOnStock = amountOnStock - orderItemsList[i].amount;

                    //updating a new amount on the stock
                    string SQLquery2 = @"UPDATE MenuItems 
                                         SET AmountOnStock = @newAmountOnStock 
                                         WHERE MenuItemId = @MenuItemId";
                    command = new SqlCommand(SQLquery2, connection);
                    command.Parameters.AddWithValue("@newAmountOnStock", newAmountOnStock);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);
                    command.ExecuteNonQuery();
                }

                else
                {
                    // write a sql query 
                    string SQLquery = @"INSERT into OrderItems (OrderId, MenuItemId, DateTaken, Amount, IsReady, Comments, IsServed)
                                VALUES (@OrderId, @MenuItemId, GETDATE(), @Amount, 0, @Comments, 0)";

                    // execute the sql query
                    SqlCommand command = new SqlCommand(SQLquery, connection);
                    command.Parameters.AddWithValue("@OrderId", order.orderID);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);
                    command.Parameters.AddWithValue("@Amount", orderItemsList[i].amount);
                    command.Parameters.AddWithValue("@Comments", orderItemsList[i].comment);

                    command.ExecuteNonQuery();

                    //getting an amount on the stock of this item
                    string SQLquery1 = @"SELECT AmountOnStock FROM MenuItems
                                         WHERE MenuItemId = @MenuItemId";
                    command = new SqlCommand(SQLquery1, connection);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        amountOnStock = int.Parse(reader["AmountOnStock"].ToString());
                    }

                    reader.Close();

                    //getting a new amount on the stock
                    newAmountOnStock = amountOnStock - orderItemsList[i].amount;

                    //updating a new amount on the stock
                    string SQLquery2 = @"UPDATE MenuItems 
                                         SET AmountOnStock = @newAmountOnStock 
                                         WHERE MenuItemId = @MenuItemId";
                    command = new SqlCommand(SQLquery2, connection);
                    command.Parameters.AddWithValue("@newAmountOnStock", newAmountOnStock);
                    command.Parameters.AddWithValue("@MenuItemId", orderItemsList[i].menuItemID);
                    command.ExecuteNonQuery();
                }
            }

            // close all connections

            CloseConnection(connection);

        }
        public List<OrderItems> getOrders(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();
            SqlConnection connection = OpeConnection();


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
            CloseConnection(connection);

            return orders;
        }
    }
}
