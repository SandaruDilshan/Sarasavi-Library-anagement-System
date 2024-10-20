using Sarasavi_Library_anagement_System.Data;
//using CloudKit;
using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        //Save Cart items

        //return copy numbers
        public async Task<string> GetCopyNumberByISBNAsync(string isbn, int count)
        {
            var books = await _conn.Table<Books>()
                .Where(b => b.ISBN == isbn)
                .OrderBy(b => b.CopyNumber) 
                .ToListAsync();

            if (count < 1 || count > books.Count)
            {
                return null; 
            }
            return books[count - 1].CopyNumber; 
        }



        public async Task<int?> GetUserNumber(string userName)
        {
            // Query the Users table to find the user with the given userName
            var user = await _conn.Table<Users>()
                .Where(u => u.user_name == userName)
                .FirstOrDefaultAsync();

            return user?.user_number;
        }

        public Task<int> SaveReservationAsync(ReservationsRequest reservation)
        {
            return _conn.InsertAsync(reservation);
        }

    //Cart
        //Get All users
        public async Task<List<Users>> GrtAllUsers()
        {
            return await _conn.Table<Users>().ToListAsync();
        }

        //Get all books
        public async Task<List<Books>> GetAllBooks()
        {
            return await _conn.Table<Books>().ToListAsync();
        }


    //BooksRegistration

        //genarate new book bumber
        public async Task<string> GenerateBookNumberAsync(String classification, String isbn)
        {
            var AllBooks = await _conn.Table<Books>().ToListAsync();

            var existBooks = AllBooks.Where(b => b.Classification == classification && b.ISBN == isbn).
                OrderBy(b => b.BookNumber).ToList();

            int NextNumber = 1;

            if (existBooks.Any())
            {
                var lastBookNumber = existBooks.Last().BookNumber;
                var lastNumberIntPart = lastBookNumber.Substring(1, 5);
                NextNumber = int.Parse(lastNumberIntPart) + 1;
            }
            return $"{classification}{NextNumber.ToString("D5")}";
        }

        //genarate copy numbers
        public async Task<List<string>> GenarateCopyNumberAsync(string bookNumber, int NumOfCopies)
        {
            var copyNumbers = new List<string>();

            await Task.Run(() =>
            {
                for (int i = 1; i <= NumOfCopies; i++)
                {
                    copyNumbers.Add($"{bookNumber}-{i}");
                }
            });

            return copyNumbers;
        }

        //Save book details
        public  Task<int> SaveBooksDetails(Books books)
        {
            return _conn.InsertAsync(books); 
        }


    //Book Categories

        //Get books categaries from BookCategqryData and send to the database
        public async Task GetBookData()
        {
            var firstcategory = await _conn.Table<BooksCatagory>().FirstOrDefaultAsync();

            if (firstcategory != null)
            {
                return;
            }

            var categories = BookCategqryData.Get();

            await _conn.InsertAllAsync(categories);
        }

        //Retreive books category from database
        public async Task<List<BooksCatagory>> GetCategary()
        {
            return await _conn.Table<BooksCatagory>().ToListAsync();
        }

        //get all books for relevent category
        public async Task<List<Books>> GetBooksByCategory(string category)
        {
            var books = await _conn.Table<Books>()
                .Where(b => b.Category == category)
                .ToListAsync();

            return books
                .GroupBy(b => b.ISBN) // Group by the unique identifier of the book (e.g., ISBN)
                .Select(g => g.First()) // Select the first book from each group
                .ToList();
        }

        //SignUp
        //genarate user number for signup
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

    //Login
        // retrieve username and password for login
        public async Task<Users> GetUsernameAndPassword(string username, string password)
        {
            return await _conn.Table<Users>()
               .Where(u => u.user_name == username && u.password == password)
               .FirstOrDefaultAsync();
        }

        public async Task<Users> IsAdmin(String admin, String username)
        {
            return await _conn.Table<Users>()
                .Where(a => a.user_name == admin && username == admin).FirstOrDefaultAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await _conn.CloseAsync();  //if application close db connection also gonna close        
        }
    }
}
