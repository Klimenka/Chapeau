using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ChapeauModel;


namespace ChapeauDAL
{
    public class LoginDAO
    {

        public static Employess CheckCredentials(Login user)
        {
            // create a sql connection
            SqlConnection connection = SqlConn.OpeConnection();

            // get a person ID
            int employeeID = GetEmployeeID(user);

            // write a sql query 
            string SQLquery = @"SELECT EmployeeId, Name, LastName, PositionId
                                FROM Employees WHERE EmployeeId = @EmployeeId ";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeID);
            command.ExecuteNonQuery();

            // read from db
            SqlDataReader reader = command.ExecuteReader();

            Employess employee = null;
            while (reader.Read())
            {
                employee = new Employess();
                employee.employeeID = (int)reader["EmployeeId"];
                employee.name = Convert.ToString(reader["Name"]);
                employee.lastName = Convert.ToString(reader["LastName"]);
                employee.positionID = (Position)reader["PositionId"];
            }

            // close all connections
            reader.Close();
            SqlConn.CloseConnection(connection);

            return employee;
        }

        public static int GetEmployeeID(Login loginInfo)
        {
            // create a sql connection
            SqlConnection connection = SqlConn.OpeConnection();

            // write a sql query 
            string sqlQuery = @"SELECT EmployeeId FROM Logins 
                                where Login = @Login AND Password = @Password";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Login", loginInfo.loginName);
            command.Parameters.AddWithValue("@Password", loginInfo.password);
            command.ExecuteNonQuery();
            SqlDataReader reader = command.ExecuteReader();

            int employeeID = 0;
            while (reader.Read())
            {
                employeeID = (int)reader["EmployeeId"];
            }

            // close all connections
            reader.Close();
            SqlConn.CloseConnection(connection);

            return employeeID;
        }



        //registraton
        public void RegisterEmployee(Position position, string name, string lastName, Login loginInfo)
        {
            // add new user to the person table
            int employeeID = GetEmployeeID(position, name, lastName);

            // add new person to the login table
            SetLoginInfo(loginInfo, employeeID);
        }

        public int GetEmployeeID(Position position, string name, string lastName)
        {
            // create a sql connection
            SqlConnection connection = SqlConn.OpeConnection();

            // write a sql query 
            string sqlQuery = @"INSERT INTO Employees(Name, LastName, PositionId) 
                                VALUES(@Name, @LastName, @PositionId)";

            string sqlQuery1 = @"SELECT EmployeeId FROM Employees 
                                 where Name = @Name AND LastName = @LastName";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@LastName", lastName);
            command.Parameters.AddWithValue("@PositionId", position);
            command.ExecuteNonQuery();

            // execute the sql query
            SqlCommand command1 = new SqlCommand(sqlQuery1, connection);
            command1.Parameters.AddWithValue("@Name", name);
            command1.Parameters.AddWithValue("@LastName", lastName);
            int employeeID = (int)command1.ExecuteScalar();

            // close the connection
            SqlConn.CloseConnection(connection);

            return employeeID;
        }

        public void SetLoginInfo(Login loginInfo, int employeeID)
        {
            // create a sql connection
            SqlConnection connection = SqlConn.OpeConnection();

            // write a sql query 
            string sqlQuery = @"INSERT INTO Logins(Login, Password, EmployeeId) 
                                VALUES(@Login, @Password, @EmployeeId)";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Login", loginInfo.loginName);
            command.Parameters.AddWithValue("@Password", loginInfo.password);
            command.Parameters.AddWithValue("@EmployeeId", employeeID);
            command.ExecuteNonQuery();

            // close the connection
            SqlConn.CloseConnection(connection);
        }


    }
}
