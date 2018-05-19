using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapeauModel
{
    public class Table
    {
        public int tableID { get; set; }
        public bool occupied { get; set; }

        public Table(int tableID, bool occupied)
        {
            this.tableID = tableID;
            this.occupied = occupied;
        }
    }
}
