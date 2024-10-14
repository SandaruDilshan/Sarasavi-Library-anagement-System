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
        public String password { get; set; }
        public String userType { get; set; }

    }
}
