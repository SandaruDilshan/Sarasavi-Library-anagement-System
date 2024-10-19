using SQLite;

namespace Sarasavi_Library_anagement_System.Data
{
    public class ReservationsRequest
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int user_number { get; set; }
        public String isbn { get; set; }
        public String coupy_number { get; set; }
        public String type { get; set; } // Read or Borrow
        public DateTime reservation_date { get; set; }
        public DateTime reservation_expire_date { get; set; }
        public String status { get; set; } = "New"; // Pending or Approved
        public String notification_message { get; set; } // After admin confirm or reject

    }    
}
