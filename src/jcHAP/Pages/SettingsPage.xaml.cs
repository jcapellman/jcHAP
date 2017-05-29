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
    }
}