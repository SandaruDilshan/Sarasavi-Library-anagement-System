using Microsoft.Maui.Controls;

namespace Sarasavi_Library_anagement_System
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            Application.Current.UserAppTheme = AppTheme.Light;

            MainPage = new NavigationPage(new Pages.LandingPage());
        }

    }
}
