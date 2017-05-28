using Windows.UI.Xaml.Navigation;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class DashboardPage : BasePage
    {
        private DashboardPageViewModel viewModel => (DashboardPageViewModel) DataContext;

        public DashboardPage()
        {
            this.InitializeComponent();

            DataContext = new DashboardPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.Load();    

            gMain.Children.Clear();
            gMain.Children.Add(viewModel.DashboardControl);
        }
    }
}