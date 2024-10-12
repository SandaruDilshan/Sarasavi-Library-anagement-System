using SQLite;

namespace Sarasavi_Library_anagement_System.Data
{
    public class Users
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public int user_number { get; set; }
        public String user_name { get; set; }
        public String gender { get; set; }
        public  String nic { get; set; }
        public String address { get; set; }

    }

    //public class history
    //{
    //    [PrimaryKey, AutoIncrement]
    //    public int id { get; set; }
    //    public int user_number { get; set; }
    //    public String coupy_number { get; set; }
    //    public String type { get; set; } // Read or Borrow
    //    public DateTime start_date { get; set; }
    //    public DateTime end_date { get; set; }
    //    public String status { get; set; } // Returned or Not Returned
    //    public String notification_message { get; set; } // After admin confirm or reject

    //}
}
