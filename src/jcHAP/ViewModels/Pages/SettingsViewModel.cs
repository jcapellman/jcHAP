using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

using Windows.Devices.WiFi;

using jcHAP.Library.Managers;
using jcHAP.Library.Objects.Settings;

namespace jcHAP.ViewModels.Pages
{
    public class SettingsViewModel : BasePageViewModel
    {
        private ObservableCollection<SettingsListingResponseItem> _settings;

        public ObservableCollection<SettingsListingResponseItem> Settings
        {
            get { return _settings; }
            set { _settings = value; OnPropertyChanged(); }
        }

        private ObservableCollection<WiFiAvailableNetwork> _wirelessNetworks;

        public ObservableCollection<WiFiAvailableNetwork> WirelessNetworks
        {
            get => _wirelessNetworks;
            set { _wirelessNetworks = value; OnPropertyChanged(); }
        }

        public async void LoadData()
        {
            Settings = new ObservableCollection<SettingsListingResponseItem>();

            var settingsManager = new SettingsManager();

            Settings = new ObservableCollection<SettingsListingResponseItem>(await settingsManager.LoadSettingsAsync());
        }

        public async Task<bool> SaveAsync()
        {
            var settingsManager = new SettingsManager();

            return await settingsManager.SaveSettingsAsync(new List<SettingsListingResponseItem>(Settings));
        }

        private async void LoadWirelessNetworks()
        {
            var access = await WiFiAdapter.RequestAccessAsync();

            // No Access - short circuit
            if (access != WiFiAccessStatus.Allowed)
            {
                return;
            }

            var result = await Windows.Devices.Enumeration.DeviceInformation.FindAllAsync(WiFiAdapter.GetDeviceSelector());

            // No WiFi Card - short circuit
            if (!result.Any())
            {
                return;
            }

            var wiFiAdapter = await WiFiAdapter.FromIdAsync(result[0].Id);

            wiFiAdapter.AvailableNetworksChanged += wifiAdapter_AvailableNetworksChanged;

            await wiFiAdapter.ScanAsync();
        }

        private void wifiAdapter_AvailableNetworksChanged(WiFiAdapter sender, object args)
        {
            var networks = sender.NetworkReport.AvailableNetworks.ToList();

            WirelessNetworks = new ObservableCollection<WiFiAvailableNetwork>(networks);
        }
    }
}