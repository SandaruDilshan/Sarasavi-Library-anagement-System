using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Data
{
    internal static class BooksData
    {
        public static List<Books> GetBooks()
        {
            return new List<Books>
            {
                new Books
                {
                    // Sample data for Fiction category
                    id = 1,
                    coupy_number = "FIC-001",
                    isbn = "978-3-16-148410-0",
                    classification = "Fiction",
                    title = "The Great Gatsby",
                    author = "F. Scott Fitzgerald",
                    status = "Available", // Available, Borrowable, etc.
                    image = "book.jpg",
                    catagory = "Fiction"
                },
                new Books
                {
                    // Sample data for Non-Fiction category
                    id = 2,
                    coupy_number = "NF-001",
                    isbn = "978-1-4028-9462-6",
                    classification = "Non-Fiction",
                    title = "Sapiens: A Brief History of Humankind",
                    author = "Yuval Noah Harari",
                    status = "Borrowable",
                    image = "book.jpg",
                    catagory = "Non-Fiction"
                },
                new Books
                {
                    // Sample data for Science category
                    id = 3,
                    coupy_number = "SCI-001",
                    isbn = "978-0-545-01022-1",
                    classification = "Science",
                    title = "A Brief History of Time",
                    author = "Stephen Hawking",
                    status = "Reference", // Available, Borrowable, Reference
                    image = "book.jpg",
                    catagory = "Science"
                }
            };
        }
    }
}
