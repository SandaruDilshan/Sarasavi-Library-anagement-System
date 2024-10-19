using Sarasavi_Library_anagement_System.Data;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Add_Users : ContentPage
{
    private readonly Database _database;

    public Add_Users()
	{
		InitializeComponent();
		_database = new Database();
	}

    private async void InitializeDatabaseAsync()
    {
        await _database.Initialize();
    }
    private async void AddUser(object sender, EventArgs e)
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
            string.IsNullOrEmpty(ConfirmPasswordEntry.Text))
        {

            await DisplayAlert("Error", "Please fill all the blanks fields", "OK");
            return;
        }

        if (checkbox == 0)
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
        string member = IsMemberCheckBox.IsChecked ? "Member" : "Visitor";

        var newUser = new Users
        {
            user_number = int.Parse(newUserNumber),
            user_name = UserNameEntry.Text,
            gender = gender,
            nic = NicEntry.Text,
            address = AddressEntry.Text,
            password = PasswordEntry.Text,
            userType = member,
        };

        await _database.SaveUserDetails(newUser);

        await DisplayAlert("Success", $"User {newUser.user_name} registered successfully with User Number: {newUserNumber}", "OK");


        UserNameEntry.Text = string.Empty;
        NicEntry.Text = string.Empty;
        AddressEntry.Text = string.Empty;
        PasswordEntry.Text = string.Empty;
        ConfirmPasswordEntry.Text = string.Empty;

        MaleCheckBox.IsChecked = false;
        FemaleCheckBox.IsChecked = false;
        OtherCheckBox.IsChecked = false;
        IsMemberCheckBox.IsChecked = false;
    }
}