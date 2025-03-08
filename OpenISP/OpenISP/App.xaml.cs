using Microsoft.Maui.Controls;

namespace OpenISP;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        // Create a new Window with MainPage as the root page
        return new Window(new MainPage());
    }
}