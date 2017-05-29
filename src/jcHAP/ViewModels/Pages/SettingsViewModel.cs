using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

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
    }
}