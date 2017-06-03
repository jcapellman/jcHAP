using Windows.UI.Xaml.Navigation;

using jcHAP.ViewModels.Pages;

namespace jcHAP.Pages
{
    public sealed partial class SensorNodesPage
    {
        private SensorNodesViewModel ViewModel => (SensorNodesViewModel) DataContext;

        public SensorNodesPage()
        {
            this.InitializeComponent();

            DataContext = new SensorNodesViewModel();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await ViewModel.LoadSensorNodes();
        }
    }
}