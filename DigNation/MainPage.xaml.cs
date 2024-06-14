using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace DigNation;


public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel(webView);
    }

    public class MainPageViewModel : BindableObject
    {
        private WebView _webView;
        private MauiProgram.ICloseApplication _closeApplication;

        public MainPageViewModel(WebView webView)
        {
            _webView = webView;
            _closeApplication = DependencyService.Get<MauiProgram.ICloseApplication>();
            RefreshCommand = new Command(RefreshWebView);
            ExitCommand = new Command(ExitApplication);
            LoadWebsiteCommand = new Command<string>(LoadWebsite);
            ShowAboutCommand = new Command(ShowAbout);
        }
        public ICommand RefreshCommand { get; }
        public ICommand ExitCommand { get; }
        public ICommand LoadWebsiteCommand { get; }
        
        public ICommand ShowAboutCommand { get; }


        private void RefreshWebView()
        {
            _webView.Reload();
        }

        private void ExitApplication()
        {
            _closeApplication.Close();
        }

        private void LoadWebsite(string url)
        {
            _webView.Source = url;
        }
        private void ShowAbout()
        {
            Application.Current.MainPage.DisplayAlert("About", "DigNation Desktop is a central applacation for all things dignation\n\nV0.2\n\nCreated and powered by HuskNZ", "OK");
        }
        
    }
}