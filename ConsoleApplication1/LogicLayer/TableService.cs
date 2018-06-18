using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ChapeauModel;
using ChapeauDAL;

namespace ChapeauLogic
{
    public class TableService
    {
        private TableDAO tableDao = new TableDAO();

        public List<Table> GetTables()
        {
            List<Table> tables = tableDao.GetTables();

            return tables;
        }

    }



}
