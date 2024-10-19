using Sarasavi_Library_anagement_System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class All_Users : ContentPage, INotifyPropertyChanged
{
	private readonly Database _database;
	public new event PropertyChangedEventHandler? PropertyChanged;

	public ObservableCollection<Users> User { get; set; }

    protected void OneProertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

	public All_Users()
	{
		InitializeComponent();
		_database = new Database();
        User = new ObservableCollection<Users>();
        BindingContext = this;

        LoadUsersAsync();
    }

    private async void LoadUsersAsync()
    {
        await _database.Initialize();
        var AllUsers = await _database.GrtAllUsers();

        if(AllUsers == null || AllUsers.Count == 0)
        {
            await DisplayAlert("Info", "No available users in the database", "OK");
            return;
        }
        User.Clear();

        foreach (var user in AllUsers)
        {
            User.Add(user);
        }
        AdminUsersCollectionView.ItemsSource = User;
    }

    void UserSearch(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(e.NewTextValue))
        {
            AdminUsersCollectionView.ItemsSource = User;
        }
        else
        {
            AdminUsersCollectionView.ItemsSource = User.Where(i => i.user_name.ToLower().Contains(e.NewTextValue.ToLower()));
        }
    }
    
}