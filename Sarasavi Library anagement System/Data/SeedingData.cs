using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
    class SeedingData
    {
        public static List<BooksCatagory> GetMenuCategories()
        {
            return new List<BooksCatagory>
        {
            new BooksCatagory { id = 1, catagory = "Beverages", image = "drink.png" },
            new BooksCatagory { id = 2, catagory = "Main Course", image = "meal.png" },
            new BooksCatagory { id = 3, catagory = "Snacks", image = "snacks.png" },
            new BooksCatagory { id = 4, catagory = "Desserts", image = "cake.png" },
            new BooksCatagory { id = 5, catagory = "Fast Food", image = "fast_food.png" }
        };
        }

        public static List<Books> GetBooks()
        {
            return new List<Books>
    {
            new Books
            {
                id = 1,
                coupy_number = "B001",
                isbn = "978-3-16-148410-0",
                classification = "Fiction",
                title = "To Kill a Mockingbird",
                author = "Harper Lee",
                status = "Borrowable",
                image = "book.png",
                catagory = "Novel"
            },
            new Books
            {
                id = 2,
                coupy_number = "B002",
                isbn = "978-0-7432-7356-5",
                classification = "Non-Fiction",
                title = "The Art of War",
                author = "Sun Tzu",
                status = "Reference",
                image = "book.png",
                catagory = "Philosophy"
            },
            new Books
            {
                id = 3,
                coupy_number = "B003",
                isbn = "978-0-452-28423-4",
                classification = "Science",
                title = "A Brief History of Time",
                author = "Stephen Hawking",
                status = "Borrowable",
                image = "book.png",
                catagory = "Physics"
            },
            new Books
            {
                id = 4,
                coupy_number = "B004",
                isbn = "978-1-56619-909-4",
                classification = "Literature",
                title = "1984",
                author = "George Orwell",
                status = "Borrowable",
                image = "book.png",
                catagory = "Dystopian"
            },
            new Books
            {
                id = 5,
                coupy_number = "B005",
                isbn = "978-0-14-044913-6",
                classification = "Classics",
                title = "The Odyssey",
                author = "Homer",
                status = "Reference",
                image = "book.png",
                catagory = "Epic"
            }
    };
        }

    }
}
