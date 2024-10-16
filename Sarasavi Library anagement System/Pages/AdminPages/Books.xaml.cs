namespace Sarasavi_Library_anagement_System.Pages.AdminPages;

public partial class Books : ContentPage
{
    internal Entry Classification;
    internal string ISBN;
    internal string Publisher;
    internal string Status;
    internal string Category;
    internal string Image;

    public Books()
	{
		InitializeComponent();
	}

    public string BookNumber { get; internal set; }
    public string CopyNumber { get; internal set; }
    public string NumOfCopies { get; internal set; }
}