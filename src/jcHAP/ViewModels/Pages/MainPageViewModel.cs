using jcHAP.Controls.Dashboard;

namespace jcHAP.ViewModels.Pages
{
    public class MainPageViewModel : BasePageViewModel
    {
        private BaseDashboardControl _dashboardControl;

        public BaseDashboardControl DashboardControl
        {
            get { return _dashboardControl; }

            set { _dashboardControl = value; OnPropertyChanged(); }
        }

        public void Load()
        {
            // Todo Pull from Settings
            DashboardControl = new TemperatureDashboard();
        }
    }
}