using Sarasavi_Library_anagement_System.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Pending_Reservations : ContentPage
{
    private readonly Database _database;
    public new event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<ReservationsRequest> PendingReservarionReq { get; set; }

    public Pending_Reservations()
	{
		InitializeComponent();
        _database = new Database();
        PendingReservarionReq = new ObservableCollection<ReservationsRequest>();
        BindingContext = this;

        LoadReservationsAsync();
    }


    private async void OnRejectTapped(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is ReservationsRequest reservation)
        {
            reservation.status = "Cancel";

            try
            {
                await _database.UpdateReservationAsync(reservation);
                await _database.DeleteReservationAsync(reservation);
                await Application.Current.MainPage.DisplayAlert("Status Updated", "Cancel reservation successfully.", "OK");

                LoadReservationsAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to update status: {ex.Message}", "OK");
            }
        }
    }

    private async void OnConfirmTapped(object sender, EventArgs e)
    {
        if (sender is Label label && label.BindingContext is ReservationsRequest reservation)
        {
            reservation.status = "Approved";
            reservation.notification_message = "Your reservation has been approved.";

            try
            {
                await _database.UpdateReservationAsync(reservation);
                await Application.Current.MainPage.DisplayAlert("Status Updated", "Reservation status set to 'Approved'.", "OK");

                LoadReservationsAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"Failed to update status: {ex.Message}", "OK");
            }
        }
    }

    private async void LoadReservationsAsync()
    {
        try
        {
            var reservations = await _database.GetPendingReservationsAsync();
            PendingReservarionReq.Clear();
            foreach (var reservation in reservations)
            {
                PendingReservarionReq.Add(reservation);
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
            AdminPendingservationsCollectionView.ItemsSource = PendingReservarionReq;
        }
        else
        {
            AdminPendingservationsCollectionView.ItemsSource = PendingReservarionReq.Where(i => i.isbn.ToString().Contains(e.NewTextValue.ToLower()));
        }
    }
}