using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class SettingsPage
    {
        private SettingsViewModel ViewModel => (SettingsViewModel) DataContext;

        public SettingsPage()
        {
            InitializeComponent();

            DataContext = new SettingsViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.LoadData();

            base.OnNavigatedTo(e);
        }

        private async void btnWifi_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await ViewModel.LoadWirelessNetworks();

            ShowMessage(result ? "WiFi Networks Loaded" : "Error loading WiFi Networks");
        }

        private async void btnSave_OnClick(object sender, RoutedEventArgs e)
        {
            var result = await ViewModel.SaveAsync();

            ShowMessage(result ? "Save Successfully" : "Save Failed");
        }
    }
}