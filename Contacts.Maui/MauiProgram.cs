using CommunityToolkit.Maui;
using Contacts.Maui.Views;
using Contacts.UseCases;
using Microsoft.Extensions.Logging;

namespace Contacts.Maui
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            builder
                .Services.ConfigurePages();

            builder
                .Services.ConfigureServices();
            return builder.Build();
        }
    }
}
