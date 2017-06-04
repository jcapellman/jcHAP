using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

using Windows.Devices.Enumeration;
using Windows.UI.Core;

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

        private ObservableCollection<DeviceInformation> _networkDevices;

        public ObservableCollection<DeviceInformation> NetworkDevices
        {
            get { return _networkDevices; }
            set { _networkDevices = value; OnPropertyChanged(); }
        }

        private bool _scanningForDevices;

        public bool ScanningForDevices
        {
            get { return _scanningForDevices; }
            set { _scanningForDevices = value; OnPropertyChanged(); }
        }

        public void LoadNetworkDevices()
        {
            ScanningForDevices = true;

            NetworkDevices = new ObservableCollection<DeviceInformation>();

            var dw = Windows.Devices.Enumeration.DeviceInformation.CreateWatcher();

            dw.Added += Dw_Added;
            dw.EnumerationCompleted += Dw_EnumerationCompleted;

            dw.Start();            
        }

        private async void Dw_EnumerationCompleted(DeviceWatcher sender, object args)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => {
                ScanningForDevices = false;
            });            
        }

        private async void Dw_Added(Windows.Devices.Enumeration.DeviceWatcher sender, Windows.Devices.Enumeration.DeviceInformation args)
        {
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => { 
                NetworkDevices.Add(args);
            });
        }
    }
}