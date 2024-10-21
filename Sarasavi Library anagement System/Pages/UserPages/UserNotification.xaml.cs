using Sarasavi_Library_anagement_System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sarasavi_Library_anagement_System.Pages;

public partial class UserNotification : ContentPage
{

    private readonly Database _database;
    public new event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ReservationsRequest> Notifications { get; set; }

    public UserNotification()
	{
		InitializeComponent();
        _database = new Database();
        Notifications = new ObservableCollection<ReservationsRequest>();
        BindingContext = this;

        LoadNotificationsAsync();
    }


    private async void OnOkTapped(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is ReservationsRequest reservation)
        {
            try
            {
                await _database.DeleteNotificationAsync(reservation);

                Notifications.Remove(reservation);

                await Application.Current.MainPage.DisplayAlert("Notification Removed", "The notification has been removed.", "OK");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to remove notification: {ex.Message}", "OK");
            }
        }
    }


    private async void LoadNotificationsAsync()
    {
        try
        {
            var reservations = await _database.GetNotificationsAsync();
            Notifications.Clear();
            foreach (var reservation in reservations)
            {
                Notifications.Add(reservation);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load reservations: {ex.Message}", "OK");
        }
    }
}