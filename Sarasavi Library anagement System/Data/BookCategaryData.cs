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
                new BooksCatagory { id = 6, catagory = "Self-Help", image = "selfhelp.png" },
                new BooksCatagory { id = 7, catagory = "Philosophy", image = "philosophy.jpg" },
                new BooksCatagory { id = 8, catagory = "Fantasy", image = "fantasy.webp" },
                new BooksCatagory { id = 9, catagory = "Romance", image = "romance.png" },
                new BooksCatagory { id = 10, catagory = "Mystery", image = "mystery.jpg" },
                new BooksCatagory { id = 11, catagory = "Horror", image = "horror.webp" },
                new BooksCatagory { id = 12, catagory = "Thriller", image = "thriller.jpeg" },
                new BooksCatagory { id = 13, catagory = "Poetry", image = "poetry.jpg" },
                new BooksCatagory { id = 14, catagory = "Drama", image = "drama.jpg" },
                new BooksCatagory { id = 15, catagory = "Adventure", image = "adventure.jpg" },
                new BooksCatagory { id = 16, catagory = "Cookbooks", image = "cookbooks.webp" },
                new BooksCatagory { id = 17, catagory = "Health & Wellness", image = "healthwellness.jpeg" },
                new BooksCatagory { id = 18, catagory = "Travel", image = "travel.jpg" },
                new BooksCatagory { id = 19, catagory = "Religion", image = "religion.jpeg" },
                new BooksCatagory { id = 20, catagory = "Psychology", image = "psychology.jpg" },
                new BooksCatagory { id = 21, catagory = "Art & Photography", image = "artphotography.jpg" },
                new BooksCatagory { id = 22, catagory = "Business", image = "business.webp" },
                new BooksCatagory { id = 23, catagory = "Comics & Graphic Novels", image = "comicsgraphicnovels.png" },
                new BooksCatagory { id = 24, catagory = "Education", image = "education.webp" },
                new BooksCatagory { id = 25, catagory = "Parenting", image = "parenting.jpeg" },
                new BooksCatagory { id = 26, catagory = "Politics", image = "politics.jpeg" },
                new BooksCatagory { id = 27, catagory = "Science Fiction", image = "sciencefiction.png" },
                new BooksCatagory { id = 28, catagory = "Music", image = "music.jpg" },
                new BooksCatagory { id = 29, catagory = "Sports", image = "sports.jpg" },
                new BooksCatagory { id = 30, catagory = "Travel Guides", image = "travelguides.webp" }
            };
        }
    }
}
