using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
    class BooksCatagory
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String catagory { get; set; }
        public String image { get; set; }

    }
}
