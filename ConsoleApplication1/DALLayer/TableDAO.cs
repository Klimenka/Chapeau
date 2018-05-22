﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class TableDAO
    {
        public static List<Table> GetTables()
        {
            SqlConnection connection = SqlConn.OpeConnection();

            string sqlQuery = @"SELECT TableId, Occupied FROM Tables";

            SqlCommand command = new SqlCommand(sqlQuery,connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Table> tables = new List<Table>();
            
            while (reader.Read())
            {
                int tableID = Convert.ToInt32(reader["TableId"]);
                bool occupied = Convert.ToBoolean(reader["Occupied"]);
                tables.Add(new Table(tableID, occupied));
            }

            reader.Close();
            SqlConn.CloseConnection(connection);

            return tables;
        }

        public static void ChangeTableStatus(Table table)
        {
            SqlConnection connection = SqlConn.OpeConnection();
            string sqlQuery = @"UPDATE Tables SET Occupied = @Occupied WHERE TableId = @TableId";

            SqlCommand command = new SqlCommand(sqlQuery, connection);
            command.Parameters.AddWithValue("@Occupied",table.occupied);
            command.Parameters.AddWithValue("@TableId", table.tableID);
            command.ExecuteNonQuery();

            SqlConn.CloseConnection(connection);
        }


    }
}
