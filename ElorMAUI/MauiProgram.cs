using Microsoft.Extensions.Logging;
using ElorMAUI.Services;
using System.Globalization;


namespace ElorMAUI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            var backendUrl = "http://localhost:8080";

            builder.Services.AddHttpClient("BackendApi", client =>
            {
                client.BaseAddress = new Uri(backendUrl);
            });

            builder.Services.AddScoped(sp =>
                sp.GetRequiredService<IHttpClientFactory>().CreateClient("BackendApi"));

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<IkastetxeService>();


            return builder.Build();
        }
    }
}
