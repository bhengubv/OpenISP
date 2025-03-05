using Microsoft.Extensions.Logging;
using OpenISP.Shared.Services;
using OpenISP.Services;

namespace OpenISP;

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

        // Add device-specific services used by the OpenISP.Shared project
        builder.Services.AddSingleton<IFormFactor, FormFactor>();

        builder.Services.AddMauiBlazorWebView();
builder.Services.AddSingleton<WiFiDirectService>();
builder.Services.AddAuthentication()
    .AddGoogle(opt => {
        opt.ClientId = "placeholder-id";
        opt.ClientSecret = "placeholder-secret";
    });
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<CreditService>();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}

