using System.Windows.Input;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;


namespace DigNation;

public partial class Settings : ContentPage
{
    public Settings()
    {
        InitializeComponent();
        BindingContext = new SettingsViewModel(Navigation);
    }

    public class SettingsViewModel : BindableObject
    {
       // private WebView _webView;
        private MauiProgram.ICloseApplication _closeApplication;
        private string _selectedDefaultPage;
        private INavigation _navigation;

        public SettingsViewModel(INavigation navigation)
        {
            
            _closeApplication = DependencyService.Get<MauiProgram.ICloseApplication>();
            //RefreshCommand = new Command(RefreshWebView);
            ExitCommand = new Command(ExitApplication);
          //  LoadWebsiteCommand = new Command<string>(LoadWebsite);
            ShowAboutCommand = new Command(ShowAbout);
            SettingsCommand = new Command(Settings);
            GoBackCommand = new Command(GoBack);
            _navigation = navigation;
        }
       // public ICommand RefreshCommand { get; }
        public ICommand ExitCommand { get; }
        //public ICommand LoadWebsiteCommand { get; }

        public ICommand ShowAboutCommand { get; }

        public ICommand SettingsCommand { get; }

        public ICommand GoBackCommand { get; }


      //  private void RefreshWebView()
        //{
         //   _webView.Reload();
        //}

        private void ExitApplication()
        {
            _closeApplication.Close();
        }

       // private void LoadWebsite(string url)
       // {
        //    _webView.Source = url;
        //}
        private void ShowAbout()
        {
            Application.Current.MainPage.DisplayAlert("About", "DigNation Desktop is a central applacation for all things dignation\n\nV0.2\n\nCreated and powered by HuskNZ", "OK");
        }
        private async void Settings()
        {
            await Shell.Current.GoToAsync("//settings");
        }
        private async void GoBack()
        {
            System.Diagnostics.Debug.WriteLine("GoBack method called");
            await Shell.Current.GoToAsync("//MainPage");
            System.Diagnostics.Debug.WriteLine("Navigation should have occurred");
        }
        public string SelectedDefaultPage
        {
            get { return _selectedDefaultPage; }
            set
            {
                if (_selectedDefaultPage != value)
                {
                    _selectedDefaultPage = value;
                    OnPropertyChanged();

                    // Set the default page route in your application settings
                    Preferences.Set("DefaultPageRoute", $"//{_selectedDefaultPage}");
                }
            }
        }
    }
}