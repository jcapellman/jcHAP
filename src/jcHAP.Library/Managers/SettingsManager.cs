using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using jcHAP.Library.DAL.SQLite;
using jcHAP.Library.DAL.SQLite.Tables;
using jcHAP.Library.Enums;
using jcHAP.Library.Objects.Settings;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.Managers
{
    public class SettingsManager : BaseManager
    {
        private const int SETTINGS_COUNT = 2;

        private async Task<List<Settings>> InitializeSettingsAsync()
        {
            using (var dbFactory = new SQLiteDAL())
            {
                var settings = new List<Settings>
                {
                    new Settings
                    {
                        TitleLabel = "Wireless Network (SSID)",
                        HelpLabel = "Enter your Wireless Network or SSID",
                        Value = string.Empty,
                        SettingsFieldType = FieldType.Text
                    },
                    new Settings
                    {
                        TitleLabel = "Wireless Network Password",
                        HelpLabel = "Password for your Wireless Network",
                        Value = string.Empty,
                        SettingsFieldType = FieldType.Password
                    }
                };

                await dbFactory.Settings.AddRangeAsync(settings);

                return settings;
            }
        }

        public async Task<List<SettingsListingResponseItem>> LoadSettingsAsync()
        {
            using (var dbFactory = new SQLiteDAL())
            {
                var result = await dbFactory.Settings.ToListAsync();

                if (!result.Any() || result.Count != SETTINGS_COUNT)
                {
                    result = await InitializeSettingsAsync();
                }

                return result.Select(a => new SettingsListingResponseItem
                {
                    Description = a.HelpLabel,
                    Label = a.TitleLabel,
                    SettingValue = a.Value,
                    ID = a.ID
                }).ToList();
            }
        }

        public async Task<bool> SaveSettingsAsync(List<SettingsListingResponseItem> settings)
        {
            using (var dbFactory = new SQLiteDAL())
            {
                foreach (var setting in settings)
                {
                    var dbItem = dbFactory.Settings.FirstOrDefault(a => a.ID == setting.ID);

                    if (dbItem == null)
                    {
                        continue;
                    }

                    dbItem.Value = setting.SettingValue;                    
                }

                await dbFactory.SaveChangesAsync();

                return true;
            }
        }
    }
}