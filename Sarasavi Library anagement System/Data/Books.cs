using SQLite;

namespace Sarasavi_Library_anagement_System.Data
{
    public class Books
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string Publisher { get; set; }
        public string Category { get; set; }
        public string Classification { get; set; }
        public string NumOfCopies { get; set; }
        public string BookNumber { get; set; } // Format: X9999X
        public string CopyNumber { get; set; } // Format: X9999X-1
        public string Status { get; set; } // Reference or Borrowable
        public string Image { get; set; }
    }

}
