using Sarasavi_Library_anagement_System.Pages;
namespace Sarasavi_Library_anagement_System.Pages;


public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

	private async void loginToHome(object sender, EventArgs e)
	{
        //await Navigation.PushAsync(new MainPage());
        Application.Current.MainPage = new AppShell();

    }

	private async void OnSignUpLabelTapped (object sender, EventArgs e)
	{
		await Navigation.PushAsync(new SignUpPage());
	}
}