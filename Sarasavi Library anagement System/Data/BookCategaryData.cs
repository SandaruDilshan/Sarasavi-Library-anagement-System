using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sarasavi_Library_anagement_System.Data
{
    internal static class BookCategqryData
    {
        public static List<BooksCatagory> Get()
        {
            return new List<BooksCatagory>
            {
                 new BooksCatagory { id = 1, catagory = "Fiction", image = "fiction.jpeg" },
                new BooksCatagory { id = 2, catagory = "Science", image = "science.jpg" },
                new BooksCatagory { id = 3, catagory = "History", image = "history.jpg" },
                new BooksCatagory { id = 4, catagory = "Technology", image = "technology.jpg" },
                new BooksCatagory { id = 5, catagory = "Biography", image = "biography.jpg" },
                new BooksCatagory { id = 6, catagory = "Self-Help", image = "self-help.png" },
                new BooksCatagory { id = 7, catagory = "Philosophy", image = "Philosophy.jpg" },
                new BooksCatagory { id = 8, catagory = "Fantasy", image = "Fantasy.webp" },
                new BooksCatagory { id = 9, catagory = "Romance", image = "Romance.png" },
                new BooksCatagory { id = 10, catagory = "Mystery", image = "Mystery.jpg" },
                new BooksCatagory { id = 11, catagory = "Horror", image = "Horror.webp" },
                new BooksCatagory { id = 12, catagory = "Thriller", image = "Thriller.jpeg" },
                new BooksCatagory { id = 13, catagory = "Poetry", image = "Poetry.jpg" },
                new BooksCatagory { id = 14, catagory = "Drama", image = "Drama.jpg" },
                new BooksCatagory { id = 15, catagory = "Adventure", image = "Adventure.jpg" },
                new BooksCatagory { id = 16, catagory = "Cookbooks", image = "Cookbooks.webp" },
                new BooksCatagory { id = 17, catagory = "Health & Wellness", image = "Health & Wellness.jpeg" },
                new BooksCatagory { id = 18, catagory = "Travel", image = "Travel.jpg" },
                new BooksCatagory { id = 19, catagory = "Religion", image = "Religion.jpeg" },
                new BooksCatagory { id = 20, catagory = "Psychology", image = "Psychology.jpg" },
                new BooksCatagory { id = 21, catagory = "Art & Photography", image = "Art & Photography.jpg" },
                new BooksCatagory { id = 22, catagory = "Business", image = "Business.webp" },
                new BooksCatagory { id = 23, catagory = "Comics & Graphic Novels", image = "Comics & Graphic Novels.png" },
                new BooksCatagory { id = 24, catagory = "Education", image = "Education.webp" },
                new BooksCatagory { id = 25, catagory = "Parenting", image = "Parenting.jpeg" },
                new BooksCatagory { id = 26, catagory = "Politics", image = "Politics.jpeg" },
                new BooksCatagory { id = 27, catagory = "Science Fiction", image = "Science Fiction.png" },
                new BooksCatagory { id = 28, catagory = "Music", image = "Music.jpg" },
                new BooksCatagory { id = 29, catagory = "Sports", image = "Sports.jpg" },
                new BooksCatagory { id = 30, catagory = "Travel Guides", image = "Travel Guides.webp" }
            };
        }
    }
}
