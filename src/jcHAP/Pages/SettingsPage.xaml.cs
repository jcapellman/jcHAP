using Windows.UI.Xaml.Navigation;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class SettingsPage
    {
        private SettingsViewModel viewModel => (SettingsViewModel) DataContext;

        public SettingsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.LoadData();

            base.OnNavigatedTo(e);
        }
    }
}