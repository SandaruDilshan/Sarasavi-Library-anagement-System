using Microsoft.Maui.Controls;
using Sarasavi_Library_anagement_System.Data;

namespace Sarasavi_Library_anagement_System.Pages;

public partial class SignUpPage : ContentPage
{
	private readonly Database _database;

	public SignUpPage()
	{
        InitializeComponent();
		_database = new Database();
        _database.Initialize();
    }


	private async void SignUpClick(object sender, EventArgs e)
	{

		int checkbox = 0;
        string gender = "";
        
        if (MaleCheckBox.IsChecked)
        {
            gender = "male";
            checkbox++;
        }
        if (FemaleCheckBox.IsChecked)
        {
            gender = "female";
            checkbox++;
        }
        if (OtherCheckBox.IsChecked)
        {
            gender = "other";
            checkbox++;
        }

        if (string.IsNullOrEmpty(UserNameEntry.Text) ||
			string.IsNullOrEmpty(NicEntry.Text) ||
			string.IsNullOrEmpty(AddressEntry.Text) ||
			string.IsNullOrEmpty(PasswordEntry.Text) ||
			string.IsNullOrEmpty(ConfirmPasswordEntry.Text ) ){

			await DisplayAlert("Error", "Please fill all the blanks fields", "OK");
			return;
		}

		if(checkbox == 0)
		{
            await DisplayAlert("Error", "Please select gender", "OK");
			return;
        }

        if (checkbox > 1)
        {
            await DisplayAlert("Error", "Can not select multiple gender", "OK");
            return;
        }


        if (PasswordEntry.Text != ConfirmPasswordEntry.Text)
        {
            await DisplayAlert("Error", "Wrong password", "OK");
            return;
        }

        //new user number
        string newUserNumber = await _database.GenerateUserNumber();
        string user_name = UserNameEntry.Text;
        string nic = NicEntry.Text;
        string address = AddressEntry.Text;
		string password = PasswordEntry.Text;

        var newUser = new Users
        {
            user_number = int.Parse(newUserNumber),
            user_name = UserNameEntry.Text,
            gender = gender,
            nic = NicEntry.Text,
            address = AddressEntry.Text,
            password = PasswordEntry.Text,
        };

        await _database.SaveUserDetails(newUser);

        await DisplayAlert("Success", $"User {newUser.user_name} registered successfully with User Number: {newUserNumber}", "OK");

        await Navigation.PushAsync(new LoginPage());
    }


    private async void OnLoginLabelTapped (object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}