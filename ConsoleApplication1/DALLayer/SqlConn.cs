﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ChapeauDAL
{
    public static class SqlConn
    {

        public static SqlConnection OpeConnection()
        {
            try
            {
                // create a string connection
                string connString =
                    ConfigurationManager.ConnectionStrings["ChapeauDBconnection"].ConnectionString;

                // create a sql connection
                SqlConnection connection = new SqlConnection(connString);

                // open the connection
                connection.Open();

                // return the connection
                return connection;

            }
            catch (SqlException e)
            {
                SqlConnection connection = null;
                Console.WriteLine(e.ToString());
                return connection;
            }
        }

        // a methos for closing the sql connection
        public static void CloseConnection(SqlConnection connection)
        {
            connection.Close();
        }


    }

}
