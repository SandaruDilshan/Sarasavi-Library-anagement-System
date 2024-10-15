namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Add_new_books : ContentPage
{
	public Add_new_books()
	{
		InitializeComponent();
	}

    private async void OnSelectImageButtonClicked(object sender, EventArgs e)
    {
        try
        {
            // Open the file picker to select an image
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Please select an image",
                FileTypes = FilePickerFileType.Images
            });

            // If a file was selected, load it into the Image view
            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
                var memoryStream = new MemoryStream();
                await stream.CopyToAsync(memoryStream);
                memoryStream.Position = 0;

                Image selectedImage = SelectedImage;
                selectedImage.Source = ImageSource.FromStream(() => memoryStream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

}