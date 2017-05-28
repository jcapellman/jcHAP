using Windows.Media.Ocr;
using Windows.UI.Xaml.Navigation;
using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class MainPage : BasePage
    {
        private MainPageViewModel viewModel => (MainPageViewModel) DataContext;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = new MainPageViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            viewModel.Load();

            gMain.Children.Add(viewModel.DashboardControl);
        }
    }
}