using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
   public class BooksCatagory
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string catagory { get; set; }
        public string image { get; set; }

    }
}
