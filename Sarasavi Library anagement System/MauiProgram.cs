using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace Sarasavi_Library_anagement_System
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder

                // Initialize the .NET MAUI Community Toolkit by adding the below line of code
			    .UseMauiCommunityToolkit()
                 
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("OpenSans-Regular.ttf", "PoppingRegular");
                    fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");

                });


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
