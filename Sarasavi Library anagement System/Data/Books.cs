using SQLite;

namespace Sarasavi_Library_anagement_System.Data
{
    public class Books
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String coupy_number { get; set; }
        public String isbn { get; set; }
        public String classification { get; set; }
        public String title { get; set; }
        public String author { get; set; }
        public String status { get; set; } // Reference or Borrowable

    }

 
}
