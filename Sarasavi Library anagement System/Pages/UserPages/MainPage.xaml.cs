using Microsoft.Maui.Controls;
using Sarasavi_Library_anagement_System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

    namespace Sarasavi_Library_anagement_System.Pages
    {
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {

        private readonly Database _database;
        public new event PropertyChangedEventHandler? PropertyChanged; // This is a delegate type that defines the signature for the PropertyChanged event. It is typically used with the INotifyPropertyChanged interface.


        public ObservableCollection<BooksCatagory> BookCategories { get; set; }
        public ObservableCollection<Books> Books { get; set; }

        public bool IsCategoryVisible { get; set; } = true;
        public bool IsBookVisible { get; set; } = false;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
            BookCategories = new ObservableCollection<BooksCatagory>();
            Books = new ObservableCollection<Books>();
            BindingContext = this;

            LoadBookCategories();

        }


        void SearchFunction(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                collectionView.ItemsSource = BookCategories;
            }
            else
            {
                collectionView.ItemsSource = BookCategories.Where(i => i.catagory.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }

        private async void LoadBookCategories()
        {
            await _database.Initialize(); // Initialize the database
            await _database.GetBookData(); // Ensure categories are populated

            var categories = await _database.GetCategary();

            if (categories == null || categories.Count == 0)
            {
                await DisplayAlert("Info", "No categories found in the database.", "OK");
            }

            BookCategories.Clear();

            foreach (var category in categories)
            {
                BookCategories.Add(category);
            }

            collectionView.ItemsSource = BookCategories;
        }

        private async void OnCatagorySelection(object sender, SelectionChangedEventArgs e)
        {
            // Check if there is a selected item  
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                // Get the selected item (assuming it's your data model)  
                var selectedItem = e.CurrentSelection.FirstOrDefault() as BooksCatagory;

                if (selectedItem != null)
                {
                    IsCategoryVisible = false;
                    IsBookVisible = true;
                    OnPropertyChanged(nameof(IsCategoryVisible));
                    OnPropertyChanged(nameof(IsBookVisible));

                    await LoadBooksForCategory(selectedItem.catagory);
                }

                // Clear the selection after displaying the alert (optional)  
                collectionView.SelectedItem = null;
            }
        }

        private async Task LoadBooksForCategory(string category)
        {
            var books = await _database.GetBooksByCategory(category);

            if (books == null || books.Count == 0)
            {
                await DisplayAlert("Info", "No books found for the selected category.", "OK");
                BooksCollectionView.ItemsSource = null; // Optionally clear the view
                return;
            }

            Books.Clear();
            foreach (var book in books)
            {
                Books.Add(book);
            }

            BooksCollectionView.ItemsSource = Books;
        }

        private async void BackToCategory(object sender, EventArgs e)
        {
            IsCategoryVisible = true;
            IsBookVisible = false;
            OnPropertyChanged(nameof(IsCategoryVisible));
            OnPropertyChanged(nameof(IsBookVisible));
        }

        void BooksSearchFunction(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.NewTextValue))
            {
                BooksCollectionView.ItemsSource = Books;
            }
            else
            {
                BooksCollectionView.ItemsSource = Books.Where(i => i.Category.ToLower().Contains(e.NewTextValue.ToLower()));
            }
        }
    }

}

