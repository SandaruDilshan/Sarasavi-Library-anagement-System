namespace Sarasavi_Library_anagement_System.Pages;

public partial class SignUpPage : ContentPage
{
	public SignUpPage()
	{
		InitializeComponent();
	}

	private async void OnLoginLabelTapped (object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoginPage());
	}
}