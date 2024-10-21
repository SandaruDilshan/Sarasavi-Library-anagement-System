
using CommunityToolkit.Maui.Core.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Controls;
using Sarasavi_Library_anagement_System.Data;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm;

    namespace Sarasavi_Library_anagement_System.Pages
    {
    public partial class MainPage : ContentPage, INotifyPropertyChanged, INotifyCollectionChanged
    {

        private readonly Database _database;
        public new event PropertyChangedEventHandler? PropertyChanged; // This is a delegate type that defines the signature for the PropertyChanged event. It is typically used with the INotifyPropertyChanged interface.

        public event NotifyCollectionChangedEventHandler CollectionChanged; 
        public ObservableCollection<BooksCatagory> BookCategories { get; set; }
        public ObservableCollection<Books> Books { get; set; }

        public bool IsCategoryVisible { get; set; } = true;
        public bool IsBookVisible { get; set; } = false;

        private ObservableCollection<CartModel> _carts;
        public ObservableCollection<CartModel> CartModel
        {
            get => _carts;
            set
            {
                _carts = value;
                OnPropertyChanged(nameof(CartModel)); // Notify that Carts has changed
            }
        }


        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IRelayCommand ReserveBooksAsyncCommand { get; }


        public MainPage()
        {
            InitializeComponent();
            _database = new Database();
            BookCategories = new ObservableCollection<BooksCatagory>();
            Books = new ObservableCollection<Books>();
            CartModel = new ObservableCollection<CartModel>(); // Ensure Carts is initialized
            ReserveBooksAsyncCommand = new AsyncRelayCommand(ReserveBooksAsync);

            BindingContext = this;

            LoadBookCategories();
        }

        // Method to handle reservation logic
        private async void ReserveBooks(object sender, EventArgs e)
        {
            if (ReservationCheckBox.IsChecked)
            {
                await ReserveBooksAsync();
            }
            else
            {
                await DisplayAlert("Alert", "Your can not reserve without agree of the conditions", "OK");

            }
        }


        [RelayCommand]
        private async Task ReserveBooksAsync()
        {
            var cartItems = CartModel.ToList();
            var userNumber = await GetUserIdfromNameAsync();

            if (!cartItems.Any())
            {
                await DisplayAlert("Error", "Your cart is empty.", "OK");
                return;
            }

            foreach (var cartItem in cartItems)
            {
                for (int count = 1; count <= cartItem.Quantity; count++)
                {
                    string copyNumber = await _database.GetCopyNumberByISBNAsync(cartItem.BookISBN, count);

                    var reservation = new ReservationsRequest
                    {
                        user_number = userNumber.Value,
                        isbn = cartItem.BookISBN,
                        coupy_number = copyNumber,
                        type = cartItem.StatusBorR ?? "Read",
                        reservation_date = DateTime.Now,
                        reservation_expire_date = DateTime.Now.AddDays(7),
                        status = "New",
                        notification_message = "Your reservation is pending approval."
                    };

                    await _database.SaveReservationAsync(reservation);
                }
            }

            await DisplayAlert("Success", "Books have been reserved.", "OK");
            CartModel.Clear();
            OnPropertyChanged(nameof(CartModel));
        }

        

        private async Task<int?> GetUserIdfromNameAsync()
        {
            var loggedUserName = Preferences.Get("LoggedInUserName", string.Empty);

            int? userNumber = await _database.GetUserNumber(loggedUserName);

            return userNumber;
        }

        //Reservations

        private void OnBorrowButtonClicked(object sender, EventArgs e)
        {
           
            if (sender is Button button && button.BindingContext is Books selectedBook)
            {
                if (UpdateTotalQuantity() < 5) { 
                    var cartItem = CartModel.FirstOrDefault(c => c.BookISBN == selectedBook.ISBN);

                    if (cartItem == null)
                    {
                        cartItem = new CartModel()
                        {
                            Image = selectedBook.Image,
                            BookISBN = selectedBook.ISBN,
                            Title = selectedBook.Title,
                            StatusBorR = "Borrow",
                            Quantity = 1
                        };
                        CartModel.Add(cartItem);
                        OnPropertyChanged(nameof(CartModel));
                        BooksReservationsCollectionView.ItemsSource = CartModel;

                    }
                    else
                    {
                        if (cartItem.StatusBorR == "Borrow")
                        {
                            cartItem.Quantity++;
                        }
                        else
                        {
                            DisplayAlert("Info", "You can select borrow or read only", "OK");
                        }
                    }
                }
                else
                {
                    DisplayAlert("Alert", "You can not reserve more than 5 Books at a time", "OK");
                    return;
                }

            }
            else
            {
                DisplayAlert("Error", "Selected book not found", "OK");
            }
        }


        private void OnReadButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button && button.BindingContext is Books selectedBook)
            {
                if (UpdateTotalQuantity() < 5)
                {
                    var cartItem = CartModel.FirstOrDefault(c => c.BookISBN == selectedBook.ISBN);

                    if (cartItem == null)
                    {
                        cartItem = new CartModel()
                        {
                            Image = selectedBook.Image,
                            BookISBN = selectedBook.ISBN,
                            Title = selectedBook.Title,
                            StatusBorR = "Read",
                            Quantity = 1
                        };
                        CartModel.Add(cartItem);
                        OnPropertyChanged(nameof(CartModel));
                        BooksReservationsCollectionView.ItemsSource = CartModel;
                    }
                    else
                    {
                        if (cartItem.StatusBorR == "Read") { 
                            cartItem.Quantity++;
                        }
                        else
                        {
                            DisplayAlert("Info", $"You can select borrow or read only {cartItem.Quantity} ", "OK");
                            return;
                        }
                    }
                }
                else
                {
                    DisplayAlert("Alert", "You can not reserve more than 5 Books at a time", "OK");
                    return;
                }
            }
        }

        //Decrease
        private void OnDecreaseQuantityButtonClicked(object sender, EventArgs e)
        {
            if (sender is Image image && image.BindingContext is CartModel cartItem)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    OnPropertyChanged(nameof(CartModel));
                }
            }
        }

        //Increase
        private void OnIncreaseQuantityButtonClicked(object sender, EventArgs e)
        {
            if (sender is Image image && image.BindingContext is CartModel cartItem)
            {
                if (UpdateTotalQuantity() < 5)
                {
                    cartItem.Quantity++;
                    OnPropertyChanged(nameof(CartModel));
                }
                else
                {
                    DisplayAlert("Alert", "You can not reserve more than 5 Books at a time", "OK");
                }
            }
        }

        //Delete item
        public void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
           CollectionChanged?.Invoke(this, e);
        }

        public void RemoveItem(object sender, EventArgs e)
        {
            if (sender is Image image && image.BindingContext is CartModel cartItem)
            {
                CartModel.Remove(cartItem);
                OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, cartItem));
            }
        }

        //Update quantity
        private int UpdateTotalQuantity()
        {
            int totalQuantity = CartModel.Sum(item => item.Quantity);
            return totalQuantity;
        }


        //Book categories
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
                BooksCollectionView.ItemsSource = null; 
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
            OnPropertyChanged(nameof(CartModel));
        }
       
    }

}

