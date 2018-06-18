using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ChapeauModel;


namespace ChapeauDAL
{
    public class LoginDAO : BaseDAO
    {

        public Employess CheckCredentials(Login user)
        {
            // create a sql connection
            SqlConnection connection = OpeConnection();

            // get an employee ID
            int employeeID = GetEmployeeID(user);

            // write a sql query 
            string SQLquery = @"SELECT EmployeeId, Name, LastName, PositionId
                                FROM Employees WHERE EmployeeId = @EmployeeId ";

            // execute the sql query
            SqlCommand command = new SqlCommand(SQLquery, connection);
            command.Parameters.AddWithValue("@EmployeeId", employeeID);

            // read from db
            SqlDataReader reader = command.ExecuteReader();
            reader.Read();

            Employess employee = new Employess // object initializer
            {
                employeeID = (int) reader["EmployeeId"],
                name = Convert.ToString(reader["Name"]),
                lastName = Convert.ToString(reader["LastName"]),
                position = (Position) reader["PositionId"]
            };

            // close all connections
            reader.Close();
            CloseConnection(connection);

            return employee;
        }

        public int GetEmployeeID(Login loginInfo)
        {
            // create a sql connection
            SqlConnection connection = OpeConnection();

            // write a sql query 
            string sqlQuery = @"SELECT EmployeeId FROM Logins 
                                where Login = @Login AND Password = @Password";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Login", loginInfo.loginName);
            command.Parameters.AddWithValue("@Password", loginInfo.password);
            int employeeID = (int)command.ExecuteScalar(); // executing an getting the first value

            CloseConnection(connection);

            return employeeID;
        }



        /***registraton part- register new users***/

        public void RegisterEmployee(Employess employee, Login loginInfo)
        {
            // add new user to the employee table
            loginInfo.employeeID = GetEmployeeID(employee);

            // add new employee to the login table
            SetLoginInfo(loginInfo);
        }

        public int GetEmployeeID(Employess employee)
        {
            // create a sql connection
            SqlConnection connection = OpeConnection();

            // write a sql query 
            string sqlQuery = @"INSERT INTO Employees(Name, LastName, PositionId) 
                                VALUES(@Name, @LastName, @PositionId)";

            string sqlQuery1 = @"SELECT EmployeeId FROM Employees 
                                 where Name = @Name AND LastName = @LastName";

            // execute the sql query
            SqlCommand insertCommand = new SqlCommand(sqlQuery, connection);
            insertCommand.Parameters.AddWithValue("@Name", employee.name);
            insertCommand.Parameters.AddWithValue("@LastName", employee.lastName);
            insertCommand.Parameters.AddWithValue("@PositionId", employee.position);
            insertCommand.ExecuteNonQuery();

            // execute the sql query
            SqlCommand selectCommand = new SqlCommand(sqlQuery1, connection);
            selectCommand.Parameters.AddWithValue("@Name", employee.name);
            selectCommand.Parameters.AddWithValue("@LastName", employee.lastName);
            int employeeID = (int)selectCommand.ExecuteScalar();

            // close the connection
            CloseConnection(connection);

            return employeeID;
        }

        public void SetLoginInfo(Login loginInfo)
        {
            // create a sql connection
            SqlConnection connection = OpeConnection();

            // write a sql query 
            string sqlQuery = @"INSERT INTO Logins(Login, Password, EmployeeId) 
                                VALUES(@Login, @Password, @EmployeeId)";

            // execute the sql query
            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Login", loginInfo.loginName);
            command.Parameters.AddWithValue("@Password", loginInfo.password);
            command.Parameters.AddWithValue("@EmployeeId", loginInfo.employeeID);
            command.ExecuteNonQuery();

            // close the connection
            CloseConnection(connection);
        }


    }
}
