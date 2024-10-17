//using CommunityToolkit.Mvvm.ComponentModel;
//using System;
//using System.Collections.Generic;
//using System.Collections.ObjectModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Input;

//using Sarasavi_Library_anagement_System.Data;
//namespace Sarasavi_Library_anagement_System.Models
//{
//    public class MainPageViewModel : ObservableObject
//    {
//        private ObservableCollection<BooksCatagory> _categories;
//        public ObservableCollection<BooksCatagory> Categories
//        {
//            get => _categories;
//            set => SetProperty(ref _categories, value);
//        }

//        private ObservableCollection<Books> _books;
//        public ObservableCollection<Books> Books
//        {
//            get => _books;
//            set => SetProperty(ref _books, value);
//        }

//        private bool _isCategoryVisible = true;
//        public bool IsCategoryVisible
//        {
//            get => _isCategoryVisible;
//            set => SetProperty(ref _isCategoryVisible, value);
//        }

//        private bool _isBookVisible = false;
//        public bool IsBookVisible
//        {
//            get => _isBookVisible;
//            set => SetProperty(ref _isBookVisible, value);
//        }

//        public ICommand LoadCategoriesCommand { get; }
//        public ICommand LoadBooksCommand { get; }

//        public MainPageViewModel()
//        {
//            InitializeComponent();
//            _database = new Database();
//            Categories = new ObservableCollection<BooksCatagory>();
//            Books = new ObservableCollection<Books>();

//            LoadCategoriesCommand = new AsyncCommand(LoadCategoriesAsync);
//            LoadBooksCommand = new AsyncCommand<BooksCatagory>(LoadBooksAsync);
//        }

//        private async Task LoadCategoriesAsync()
//        {
//            var categories = await App.DatabaseService.GetCategoriesAsync();
//            Categories.Clear();
//            foreach (var category in categories)
//            {
//                Categories.Add(category);
//            }
//            IsCategoryVisible = true;
//            IsBookVisible = false;
//        }

//        private async Task LoadBooksAsync(BooksCatagory selectedCategory)
//        {
//            var books = await App._databasesa.GetBooksByCategoryAsync(selectedCategory.Category);
//            Books.Clear();
//            foreach (var book in books)
//            {
//                Books.Add(book);
//            }
//            IsCategoryVisible = false;
//            IsBookVisible = true;
//        }
//    }
//}
