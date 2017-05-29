using Windows.UI.Xaml.Navigation;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class DashboardPage
    {
        private DashboardPageViewModel ViewModel => (DashboardPageViewModel) DataContext;

        public DashboardPage()
        {
            InitializeComponent();

            DataContext = new DashboardPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ViewModel.Load();    

            gMain.Children.Clear();
            gMain.Children.Add(ViewModel.DashboardControl);
        }
    }
}