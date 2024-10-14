using Sarasavi_Library_anagement_System.Data;
using Sarasavi_Library_anagement_System.Pages;
namespace Sarasavi_Library_anagement_System.Pages;


public partial class LoginPage : ContentPage
{
	private readonly Database _database;

	public LoginPage()
	{
		InitializeComponent();
		_database = new Database();
	}

    private async void InitializeDatabaseAsync()
    {
        await _database.Initialize();
    }

    private async void loginToHome(object sender, EventArgs e)
	{
		string username = UserNameEntry.Text;
		string password = PasswordEntry.Text;

		if(string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
		{
			await DisplayAlert("Error", "Please fill all the balank fields", "OK");
			return;
        }

		var user = await _database.GetUsernameAndPassword(username, password);

        if (user != null)
		{
			await DisplayAlert("Success", "Login successfull", "OK");
			Application.Current.MainPage = new AppShell();
		}
        else
        {
            await DisplayAlert("Error", "Invalid username or password", "OK");
        }
    }

	private async void OnSignInLabelTapped(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SignUpPage());
	}
}