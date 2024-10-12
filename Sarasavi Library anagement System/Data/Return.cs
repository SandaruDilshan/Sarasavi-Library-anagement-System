using SQLite;

namespace Sarasavi_Library_anagement_System.Data
{
    public class Return
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int user_number { get; set; }
        public String isbn { get; set; }
        public String coupy_number { get; set; }
        public DateTime return_date { get; set; }
        public String status { get; set; } // Returned or Not Returned
        public String notification_message { get; set; } // After admin confirm or reject
    }

}
