using Microsoft.Maui.Controls;
using Sarasavi_Library_anagement_System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Sarasavi_Library_anagement_System.Pages
{
    public partial class MainPage : ContentPage
    {
        private readonly Database _database;
        public ObservableCollection<BooksCatagory> BookCategories { get; set; }

        public MainPage()
        {
            InitializeComponent();
            _database = new Database(); // Initialize the database connection  
            BookCategories = new ObservableCollection<BooksCatagory>();
            BindingContext = this; // Set the BindingContext to this page for data binding  

            LoadBookCategories();
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

            // Clear existing data
            BookCategories.Clear();

            // Add the fetched categories to the ObservableCollection
            foreach (var category in categories)
            {
                BookCategories.Add(category);
            }

            // Set the ItemsSource of the CollectionView
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
                    // Display an alert with the category of the selected item  
                    await DisplayAlert("Selected Category", $"Category: {selectedItem.catagory}", "OK");
                }

                // Clear the selection after displaying the alert (optional)  
                collectionView.SelectedItem = null;
            }
        }
    }
}

