using System.Collections.Generic;
using System.Collections.ObjectModel;

using jcHAP.Objects;

namespace jcHAP.ViewModels.Controls
{
    public class TemperatureDashboardViewModel : BaseControlsViewModel
    {
        private ObservableCollection<TemperatureDashboardItem> _temperatures;

        public ObservableCollection<TemperatureDashboardItem> Temperatures {
            get => _temperatures;
            set { _temperatures = value; OnPropertyChanged(); }
        }

        public void LoadData()
        {
            var data = getData<List<TemperatureDashboardItem>>();

            if (data == null)
            {
                return;
            }

            Temperatures = new ObservableCollection<TemperatureDashboardItem>(data);
        }
        
        protected override string GetName() => "TemperatureDashboard";
    }
}