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
            SaveCommand = new Command(Save);
            LoadCommand = new Command(Load);
        }
       // public ICommand RefreshCommand { get; }
        public ICommand ExitCommand { get; }
        //public ICommand LoadWebsiteCommand { get; }

        public ICommand ShowAboutCommand { get; }

        public ICommand SettingsCommand { get; }

        public ICommand GoBackCommand { get; }
        
        public ICommand SaveCommand { get; }
        
        public ICommand LoadCommand { get; }
        
      //  public void SaveSettings()
        //{
          //  var settings = new SettingsData
            //{
              //  DarkMode = ThemeSwitch.IsToggled,
                //Language = LanguagePicker.SelectedItem.ToString(),
                //EnableNotifications = NotificationSwitch.IsToggled,
                //EnableAutoUpdates = AutoUpdateSwitch.IsToggled
            //};

            //var json = System.Text.Json.JsonSerializer.Serialize(settings);
            //System.IO.File.WriteAllText("settings.json", json);
        //}


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
        private void Save()
        {
            Application.Current.MainPage.DisplayAlert("Save this config", "This button is work in progress and will let you save your config to your device or somewhere else", "Please click here to close this");
        }
        private void Load()
        {
            Application.Current.MainPage.DisplayAlert("Load Config", "This button is work in progress and will let you load a config from your device or a vaild URL", "Please click here to close this");
        }
        private async void Settings()
        {
            Application.Current.MainPage.DisplayAlert("Silly", "Your alredy in settings", "Ok");
        }
        private async void GoBack()
        {
            System.Diagnostics.Debug.WriteLine("GoBack method called");
            await Shell.Current.GoToAsync("//MainPage");
            System.Diagnostics.Debug.WriteLine("Navigation should have occurred");
        }
                
        }
    }
