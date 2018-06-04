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

        //get orders from DB for kitchen/bar form
        public List<OrderItems> getOrders(int ID)
        {
            List<OrderItems> orders = new List<OrderItems>();
            SqlConnection connection = OpeConnection();


            // write a sql query 
            string SQLquery = @"SELECT c.OrderItemId, a.TableId, b.ItemName, c.Amount, c.isReady, c.IsServed from Orders as a
                                INNER JOIN OrderItems as c ON c.OrderId = a.OrderId
                                INNER JOIN MenuItems as b ON c.MenuItemId = b.MenuItemId
                                WHERE a.EmployeeId = @ID AND convert (date, DateTaken) = convert (date, GETDATE()) ";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                OrderItems order = new OrderItems();
                order.orderItemID = (int)reader["OrderItemId"];
                order.tableID = (int)reader["TableId"];
                order.itemName = Convert.ToString(reader["ItemName"]);
                order.amount = (int)reader["Amount"];
                order.isReady = (bool)reader["isReady"];
                order.isServed = (bool)reader["IsServed"];
               
                //add order to then list
                orders.Add(order);
            }

            // close all connections
            reader.Close();
            CloseConnection(connection);

            //return orders list
            return orders;
        }

        public List<OrderItems> GetExistedOrderItems(Order existedOrder)
        {
            List<OrderItems> orderItems = new List<OrderItems>();
            SqlConnection connection = OpeConnection();


            // write a sql query 
            string SQLquery = @"SELECT OrderItemId, MenuItemId, Amount, Comments, IsServed  FROM OrderItems 
                                WHERE OrderId = @OrderId";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@OrderId", existedOrder.orderID);
            command.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                OrderItems orderItem = new OrderItems();
                orderItem.orderItemID = (int)reader["OrderItemId"];
                orderItem.menuItemID = (int)reader["MenuItemId"];
                orderItem.amount = (int)reader["Amount"];
                orderItem.comment = Convert.ToString(reader["Comments"]);
                orderItem.isServed = (bool)reader["IsServed"];

                //add to orderitems list
                orderItems.Add(orderItem);
            }

            // close all connections
            reader.Close();
            CloseConnection(connection);


            return orderItems;
        }
        public void CheckAsServedItems(int[] checkedItems)
        {
            SqlConnection connection = OpeConnection();

            for (int i = 0; i < checkedItems.Length; i++)
            {
                // write a sql query 
                string SQLquery = @"UPDATE OrderItems
                                SET IsServed = 1
                                WHERE OrderItemId = @OrderItemId";

                // execute the sql query
                SqlCommand command = new SqlCommand(SQLquery, connection);
                command.Parameters.AddWithValue("@OrderItemId", checkedItems[i]);
                command.ExecuteNonQuery();
            }
            CloseConnection(connection);
        }



        //Kitchen items
        public List<OrderItems> getOrderItemsKitchen()
        {
            List<OrderItems> orderitems = new List<OrderItems>();
            SqlConnection connection = OpeConnection();


            // write a sql query for Kitchen output
            string SQLquery = @"SELECT a.OrderId, a.OrderItemId, b.ItemName, a.Comments, a.Amount, b.CategoryId from OrderItems as a
                                INNER JOIN MenuItems as b ON a.MenuItemId = b.MenuItemId
                                WHERE IsReady = 0 AND convert (date, DateTaken) = convert (date, GETDATE()) AND b.BarOrKitchen = 1
                                ORDER BY DateTaken";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            
            //command.ExecuteNonQuery();

            // read from DB
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                OrderItems order = new OrderItems();
                order.orderID = (int)reader["OrderId"];
                order.orderItemID = (int)reader["OrderItemId"];
                order.itemName = Convert.ToString(reader["ItemName"]);
                order.comment = Convert.ToString(reader["Comments"]);
                order.amount = (int)reader["Amount"];
                order.category = (Category)reader["CategoryId"];

                //add to orderitems list
                orderitems.Add(order);
            }    
            
            reader.Close();


            // close all connections
            CloseConnection(connection);

            return orderitems;
        }

        //Bar Items
        public List<OrderItems> getOrderItemsBar()
        {
            List<OrderItems> orderitems = new List<OrderItems>();
            SqlConnection connection = OpeConnection();


            // write a sql query 
            string SQLquery = @"SELECT a.OrderId, a.OrderItemId, b.ItemName, a.Comments, a.Amount, b.CategoryId from OrderItems as a
                                INNER JOIN MenuItems as b ON a.MenuItemId = b.MenuItemId
                                WHERE IsReady = 0 AND convert (date, DateTaken) = convert (date, GETDATE()) AND b.BarOrKitchen = 0
                                ORDER BY DateTaken";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);

            
            // read from DB
            SqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                OrderItems order = new OrderItems();
                order.orderID = (int)reader["OrderId"];
                order.orderItemID = (int)reader["OrderItemId"];
                order.itemName = Convert.ToString(reader["ItemName"]);
                order.comment = Convert.ToString(reader["Comments"]);
                order.amount = (int)reader["Amount"];
                order.category = (Category)reader["CategoryId"];

                //add to orderitems list
                orderitems.Add(order);
            }


            reader.Close();

            // close all connections
            CloseConnection(connection);

            return orderitems;
        }

        //change items state to READY (1)
        public void CheckAsReadyItems(int[] checkedItems)
        {
            SqlConnection connection = OpeConnection();

            for (int i = 0; i < checkedItems.Length; i++)
            {
                // write a sql query 
                string SQLquery = @"UPDATE OrderItems
                                SET IsReady = 1, DateReady = GETDATE()
                                WHERE OrderItemId = @OrderItemId";

                // execute the sql query
                SqlCommand command = new SqlCommand(SQLquery, connection);
                command.Parameters.AddWithValue("@OrderItemId", checkedItems[i]);
                command.ExecuteNonQuery();

            }
            CloseConnection(connection);
        }

    }
}
