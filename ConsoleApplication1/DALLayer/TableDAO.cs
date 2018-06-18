using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;

namespace ChapeauDAL
{
    public class TableDAO : BaseDAO
    {
        public List<Table> GetTables()
        {
            SqlConnection connection = OpeConnection();

            string sqlQuery = @"SELECT TableId, Occupied FROM Tables";

            SqlCommand command = new SqlCommand(sqlQuery, connection);

            SqlDataReader reader = command.ExecuteReader();

            List<Table> tables = new List<Table>();

            // read data from database
            while (reader.Read())
            {
                int tableID = Convert.ToInt32(reader["TableId"]);
                bool occupied = Convert.ToBoolean(reader["Occupied"]);
                tables.Add(new Table(tableID, occupied));
            }

            // close all connections
            reader.Close();
            CloseConnection(connection);

            return tables;
        }

    }
}
