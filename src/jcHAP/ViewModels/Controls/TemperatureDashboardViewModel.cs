using System;

namespace jcHAP.ViewModels.Controls
{
    public class TemperatureDashboardViewModel : BaseControlsViewModel
    {
        private string _temperature;

        public string Temperature {  get { return _temperature; } set { _temperature = value; OnPropertyChanged(); } }

        public TemperatureDashboardViewModel()
        {
            Temperature = "44.4'F";
        }
    }
}