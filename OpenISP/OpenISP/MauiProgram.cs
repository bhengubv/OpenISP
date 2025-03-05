using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Hosting;
using Microsoft.Maui.Hosting;
using OpenISP.Shared.Services; // For IWiFiDirectService, DefaultWiFiDirectService, IFormFactor, FormFactor, CustomAuthService
using OpenISP.Services; // For AndroidWiFiDirectService
#if ANDROID
using Android.App;
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

namespace OpenISP
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

            // Add device-specific services used by OpenISP.Shared
            builder.Services.AddSingleton<IFormFactor, FormFactor>();

            // Register IWiFiDirectService with platform-specific implementation
#if ANDROID
            builder.Services.AddSingleton<IWiFiDirectService>(provider =>
            {
                var mauiContext = provider.GetRequiredService<IMauiContext>();
                var activity = mauiContext.Context as Activity ?? throw new InvalidOperationException("Activity not found");
                return new AndroidWiFiDirectService(activity);
            });
#else
            builder.Services.AddSingleton<IWiFiDirectService, DefaultWiFiDirectService>();
#endif

            // MAUI Blazor Hybrid services
            builder.Services.AddMauiBlazorWebView();

            // Register custom auth service (replacing AuthenticationStateProvider)
            builder.Services.AddScoped<CustomAuthService>();
            builder.Services.AddSingleton<CreditService>();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}