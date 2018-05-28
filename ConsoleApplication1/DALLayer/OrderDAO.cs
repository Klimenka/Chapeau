using ChapeauModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauDAL
{
    public class OrderDAO : BaseDAO
    {
        public Order NewOrder(int empId, int tableID)
        
        {
            Order order = new Order();

            SqlConnection connection = OpeConnection();


            // write a sql query 
            string SQLquery = @"INSERT INTO Orders (EmployeeId, TableId) values (@EmpID, @tableID)";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@EmpID", empId);
            command.Parameters.AddWithValue("@tableID", tableID);
            command.ExecuteNonQuery();

            string sqlQuery2 = @"select  TOP 1 OrderId from Orders 
                         where EmployeeId = @EmpID AND TableId = @tableID
                         order by OrderId desc";
            SqlCommand command2 = new SqlCommand(sqlQuery2, connection);
            command2.Parameters.AddWithValue("@EmpID", empId);
            command2.Parameters.AddWithValue("@tableID", tableID);
            command2.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command2.ExecuteReader();


            while (reader.Read())
            {
                order.orderID = (int)reader["OrderId"];
                
            }
           

            // close all connections
            reader.Close();
            CloseConnection(connection);

            order.tableID = tableID;
            order.employeeID = empId;

            return order;
        }

        public int GetOrderIdDB(int tableIdExistedOrder)
        {
            int orderID = 0;
            SqlConnection connection = OpeConnection();


            // write a sql query 
            string SQLquery = @"SELECT TOP 1 OrderId FROM Orders
                                WHERE TableId = @TableId
                                ORDER BY OrderId desc";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@tableID", tableIdExistedOrder);
            command.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orderID = (int)reader["OrderId"];

            }


            // close all connections
            reader.Close();
            CloseConnection(connection);

            return orderID;
        }
    }


    }

