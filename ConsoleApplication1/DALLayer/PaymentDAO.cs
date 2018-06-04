using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using System.Data.SqlClient;

namespace ChapeauDAL
{
    public class PaymentDAO : BaseDAO
    {
        public List<MenuItem> MenuItems(int orderID)
        {
            //open connection
            SqlConnection connection = OpeConnection();

            string sqlQuery = @"select M.ItemName, M.Price, M.VAT, O.Amount from OrderItems
                                as O join MenuItems as M on O.MenuItemId = M.MenuItemId
                                where OrderId = @orderID"; //order ID from the table equals the order ID parameter

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("orderID", orderID);
            command.ExecuteNonQuery();

            SqlDataReader reader = command.ExecuteReader(); //execute the query

            List<MenuItem> menuItems = new List<MenuItem>();

            while (reader.Read())
            {
                MenuItem item = new MenuItem();

                item.itemName = Convert.ToString(reader["ItemName"]);
                item.price = Convert.ToSingle(reader["Price"]);
                item.vatPercentage = Convert.ToSingle(reader["VAT"]);
                item.amount = Convert.ToInt32(reader["Amount"]);

                menuItems.Add(item);
            }

            reader.Close();

            CloseConnection(connection);

            return menuItems;
        }


        public void StorePayment(Payment payment, int tableID)
        {
            //open connection
            SqlConnection connection = OpeConnection();

            string sqlQuery = @"Insert into Payments(OrderId, DateTime, PaymentMethodId, Tips, EmployeeId, feedback)
                                values (@OrderId, GETDATE(), @PaymentMethodId, @Tips, @EmployeeId, @feedback)";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@OrderId",payment.orderID);
            command.Parameters.AddWithValue("@PaymentMethodId", (int)payment.paymentMethod);
            command.Parameters.AddWithValue("@Tips", payment.tip);
            command.Parameters.AddWithValue("@EmployeeId", payment.employeeID);
            command.Parameters.AddWithValue("@feedback", payment.feedback);

            command.ExecuteNonQuery();

            //Occupied ----> set as 0
            string SQLquery2 = @"UPDATE Tables SET Occupied = 0
                                WHERE tableId = @tableId";

            // execute the sql query
            SqlCommand command2 = new SqlCommand(SQLquery2, connection);
            command2.Parameters.AddWithValue("@tableId", tableID);
            command2.ExecuteNonQuery();

            CloseConnection(connection);

        }


    }
}
