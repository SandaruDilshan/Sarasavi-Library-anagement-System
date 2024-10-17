using Microsoft.Maui.Controls;
using Sarasavi_Library_anagement_System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class All_Books : ContentPage, INotifyPropertyChanged
{
	private readonly Database _database;
	public new event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<Books> Books { get; set; }

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }


    public All_Books()
	{
		InitializeComponent();
        _database = new Database();
        Books = new ObservableCollection<Books>();
        BindingContext = this;

        LoadBooksAsync();

    }

    private async void LoadBooksAsync()
    {
        await _database.Initialize();
        var AllBooks = await _database.GetAllBooks();

        if(AllBooks == null || AllBooks.Count == 0)
        {
            await DisplayAlert("Info","No available books in the database","OK");
        }
        Books.Clear();

        foreach( var book in AllBooks)
        {
            Books.Add(book);
        }
        AdminBooksView.ItemsSource = Books;
    }

    void BookSearchAdminFunction(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(e.NewTextValue))
        {
            AdminBooksView.ItemsSource = Books;
        }
        else
        {
            AdminBooksView.ItemsSource = Books.Where(i => i.Title.ToLower().Contains(e.NewTextValue.ToLower()) || i.ISBN.ToLower().Contains(e.NewTextValue.ToLower()) || i.Publisher.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }

}