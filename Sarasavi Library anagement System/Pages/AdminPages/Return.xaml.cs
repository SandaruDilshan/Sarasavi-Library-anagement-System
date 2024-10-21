using Sarasavi_Library_anagement_System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
//using Windows.UI.Notifications;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Return : ContentPage
{
    private readonly Database _database;
    public new event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ReservationsRequest> Returns { get; set; }

    public Return()
	{
		InitializeComponent();
        _database = new Database();
        Returns = new ObservableCollection<ReservationsRequest>();
        BindingContext = this;

        LoadReturnsAsync();
    }



    private async void OnConfirmTapped(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is ReservationsRequest reservation)
        {
            reservation.status = "Cancel";

            try
            {
                await _database.UpdateReservationAsync(reservation);
                await _database.DeleteReservationAsync(reservation);
                await Application.Current.MainPage.DisplayAlert("Status Updated", "Reservation status set to 'Approved'.", "OK");

                LoadReturnsAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to update status: {ex.Message}", "OK");
            }
        }
    }

    private async void LoadReturnsAsync()
    {
        try
        {
            var reservations = await _database.GetReturnAsync();
            Returns.Clear();
            foreach (var reservation in reservations)
            {
                Returns.Add(reservation);
            }
        }
        catch (Exception ex)
        {
            await Application.Current.MainPage.DisplayAlert("Error", $"Failed to load reservations: {ex.Message}", "OK");
        }
    }

    void ReservationsSearch(System.Object sender, Microsoft.Maui.Controls.TextChangedEventArgs e)
    {
        if (String.IsNullOrWhiteSpace(e.NewTextValue))
        {
            AdminReturnCollectionView.ItemsSource = Returns;
        }
        else
        {
            AdminReturnCollectionView.ItemsSource = Returns.Where(i => i.isbn.ToString().Contains(e.NewTextValue.ToLower()));
        }
    }

}