using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
    internal class Database : IAsyncDisposable
    {
        private readonly SQLiteAsyncConnection _conn;
        public Database()
        {
            var dbpath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "SarasaviDB.db3");
            _conn = new SQLiteAsyncConnection(dbpath,
                    SQLiteOpenFlags.Create | SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.SharedCache);
        }

        public async Task Initialize()
        {
            try
            {
                // if there is no table in the database, it will create the table
                await _conn.CreateTableAsync<Users>();
                await _conn.CreateTableAsync<Books>();
                await _conn.CreateTableAsync<BooksCatagory>();
                await _conn.CreateTableAsync<ReservationsRequest>();
                await _conn.CreateTableAsync<Return>();

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Error initializing database:", "OK");
            }
        }


        //genarate user number
        public async Task<string> GenerateUserNumber()
        {
            var lastUser = await _conn.Table<Users>()
                                         .OrderByDescending(u => u.id)
                                         .FirstOrDefaultAsync();

            int nextNumber = 1;

            if (lastUser != null)
            {
                nextNumber = lastUser.user_number + 1;
            }

            return nextNumber.ToString("D5"); // Formatting usre number for 5 digits
        }

        public Task<int> SaveUserDetails(Users user)
        {
            return _conn.InsertAsync(user); // insert user details
        }

        public async ValueTask DisposeAsync()
        {
            await _conn.CloseAsync();  //if application close db connection also gonna close        
        }
    }
}
