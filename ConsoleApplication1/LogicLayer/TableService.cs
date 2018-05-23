using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using ChapeauDAL;

namespace ChapeauLogic
{
    public class TableService
    {
        public static List<Table> GetTables()
        {
            List<Table> tables = null;
            try
            {
                tables = TableDAO.GetTables();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }

            return tables;
        }

        public static void ChangeTableStatus(Table table)
        {
            try
            {
                TableDAO.ChangeTableStatus(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
}
