using System.Linq;
using Microsoft.Maui.Platform;
using Sarasavi_Library_anagement_System.Data;
//using SoundAnalysis;

namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Add_new_books : ContentPage
{
    private readonly Database _database;
    private static String _selectedImagePath;

    public Add_new_books()
    {
        InitializeComponent();
        _database = new Database();
        InitializeDatabase();

    }

    private async void InitializeDatabase() 
    {
        await _database.Initialize();
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

                _selectedImagePath = result.FullPath;
                Image selectedImage = SelectedImage;
                selectedImage.Source = ImageSource.FromStream(() => memoryStream);
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
        }
    }

    public async void AddBooks(object sender, EventArgs e)
    {
        int checkbox = 0;
        string status = "";

        if (borrowablecheck.IsChecked)
        {
            status = "Borrowable";
            checkbox++;
        }
        if (referencecheck.IsChecked)
        {
            status = "Reference";
            checkbox++;
        }

        string Titles = title.Text;
        string Isbns = isbn.Text;
        string Publishers = publisher.Text;
        string Categorys = category.Text;
        string Classfications = classification.Text;
        string Copiess = copies.Text;
        string Status = status;
        string ImgPath = _selectedImagePath;

        if (string.IsNullOrEmpty(Titles) ||
               string.IsNullOrEmpty(Isbns) ||
               string.IsNullOrEmpty(Publishers) ||
               string.IsNullOrEmpty(Categorys) ||
               string.IsNullOrEmpty(classification.Text) ||
               string.IsNullOrEmpty(Copiess) ||
               string.IsNullOrEmpty(Status) ||
               _selectedImagePath == null
               )
        {
            await DisplayAlert("Error", "Please fill all the blanks fields", "OK");
            return;
        }

        if (checkbox == 0)
        {
            await DisplayAlert("Error", "Please select status", "OK");
            return;
        }

        if (checkbox > 1)
        {
            await DisplayAlert("Error", "Can not select multiple status", "OK");
            return;
        }

        if (!int.TryParse(copies.Text, out int numOfCopies) || numOfCopies <= 0)
        {
            await DisplayAlert("Error", "Number of copies must be a positive integer.", "OK");
            return;
        }

        Classfications = classification.Text.ToUpper();
        string bookNumber = await _database.GenerateBookNumberAsync(Classfications, Isbns);

        List<String> copyNumbers = await _database.GenarateCopyNumberAsync(bookNumber, numOfCopies);

        foreach (var copyNumber in copyNumbers)
        {
            var newBook = new Sarasavi_Library_anagement_System.Data.Books
            {
                Title = Titles,
                ISBN = Isbns,
                Publisher = Publishers,
                Category = Categorys,
                Classification = Classfications,
                NumOfCopies = Copiess,
                BookNumber = bookNumber,
                CopyNumber = copyNumber,
                Status = Status,
                Image = ImgPath
            };
            await _database.SaveBooksDetails(newBook);
        }

        await DisplayAlert("Success", "Book added successfully!", "OK");
        ClearForm();

    }

    private void ClearForm()
    {
        title.Text = string.Empty;
        isbn.Text = string.Empty;
        publisher.Text = string.Empty;
        category.Text = string.Empty;
        classification.Text = string.Empty;
        copies.Text = string.Empty;
        borrowablecheck.IsChecked = false;
        referencecheck.IsChecked = false;
        SelectedImage.Source = null;
        _selectedImagePath = string.Empty;
    }
}
