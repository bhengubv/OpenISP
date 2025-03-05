using Microsoft.Maui.Controls;

namespace OpenISP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(); // Assuming MainPage hosts the BlazorWebView
        }
    }
}