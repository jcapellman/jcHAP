using jcHAP.ViewModels.Controls;

namespace jcHAP.Controls.Dashboard
{
    public sealed partial class TemperatureDashboard : BaseDashboardControl
    {
        public TemperatureDashboard()
        {
            InitializeComponent();

            DataContext = new TemperatureDashboardViewModel();
        }
    }
}