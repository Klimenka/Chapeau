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
        TableDAO tableDAO = new TableDAO();

        public List<Table> GetTables()
        {
            List<Table> tables = null;
            try
            {
                tables = tableDAO.GetTables();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); 
            }

            return tables;
        }

        public void ChangeTableStatus(Table table)
        {
            try
            {
                tableDAO.ChangeTableStatus(table);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


    }
}
