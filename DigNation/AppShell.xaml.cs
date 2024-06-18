namespace DigNation;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("main", typeof(MainPage));
        Routing.RegisterRoute("settings", typeof(Settings));
        
    }
}