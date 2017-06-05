using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Windows.Devices.Enumeration;

using jcHAP.Library.DAL.SQLite.Tables;
using jcHAP.Library.Managers;

namespace jcHAP.ViewModels.Pages
{
    public class SensorNodesViewModel : BasePageViewModel
    {
        private ObservableCollection<SensorNodes> _sensorNodes;

        public ObservableCollection<SensorNodes> SensorNodes
        {
            get => _sensorNodes;
            set { _sensorNodes = value; OnPropertyChanged(); }
        }

        public async Task<bool> LoadSensorNodes()
        {
            var snManager = new SensorNodeManager();

            var nodes = await snManager.GetSensorNodes();
            
            SensorNodes = new ObservableCollection<SensorNodes>(nodes);

            return true;
        }

        private ObservableCollection<DeviceInformation> _networkDevices;

        public ObservableCollection<DeviceInformation> NetworkDevices
        {
            get => _networkDevices;
            set { _networkDevices = value; OnPropertyChanged(); }
        }

        private bool _scanningForDevices;

        public bool ScanningForDevices
        {
            get => _scanningForDevices;
            set { _scanningForDevices = value; OnPropertyChanged(); }
        }

        public async void LoadNetworkDevices()
        {
            ScanningForDevices = true;

            NetworkDevices = new ObservableCollection<DeviceInformation>();

            var devices = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(string.Empty, null, DeviceInformationKind.AssociationEndpoint);

            foreach (var device in devices)
            {
                NetworkDevices.Add(device);
            }

            ScanningForDevices = false;
        }
    }
}