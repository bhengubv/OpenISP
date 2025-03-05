using Microsoft.UI.Xaml;

using OpenISP; // For MauiProgram

namespace OpenISP.WinUI
{
    public partial class App : MauiWinUIApplication
    {
        public App()
        {
            // No InitializeComponent() needed; root App.xaml handles initialization
        }

        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}