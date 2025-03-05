using OpenISP.Web.Components;
using OpenISP.Shared.Services;
using OpenISP.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add device-specific services used by the OpenISP.Shared project
builder.Services.AddSingleton<IFormFactor, FormFactor>();

// Register custom auth service (replacing AuthenticationStateProvider)
builder.Services.AddScoped<CustomAuthService>();
builder.Services.AddSingleton<CreditService>();

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

var app = builder.Build();

app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(OpenISP.Shared._Imports).Assembly);

app.Run();
