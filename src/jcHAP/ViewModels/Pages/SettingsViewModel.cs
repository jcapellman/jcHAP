using System.Collections.ObjectModel;

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

        public void LoadData()
        {
            Settings = new ObservableCollection<SettingsListingResponseItem>();

            var settingsManager = new SettingsManager();

            Settings = new ObservableCollection<SettingsListingResponseItem>(settingsManager.LoadSettings());
        }
    }
}