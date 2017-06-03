using System.Collections.ObjectModel;
using System.Threading.Tasks;

using jcHAP.Library.DAL.SQLite.Tables;
using jcHAP.Library.Managers;

namespace jcHAP.ViewModels.Pages
{
    public class SensorNodesViewModel : BasePageViewModel
    {
        private ObservableCollection<SensorNodes> _sensorNodes;

        public ObservableCollection<SensorNodes> SensorNodes
        {
            get { return _sensorNodes; }
            set { _sensorNodes = value; OnPropertyChanged(); }
        }

        public async Task<bool> LoadSensorNodes()
        {
            var snManager = new SensorNodeManager();

            var nodes = await snManager.GetSensorNodes();
            
            SensorNodes = new ObservableCollection<SensorNodes>(nodes);

            return true;
        }
    }
}
