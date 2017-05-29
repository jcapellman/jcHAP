using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using jcHAP.Library.DAL.SQLite;
using jcHAP.Library.DAL.SQLite.Tables;
using jcHAP.Library.Objects.Settings;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.Managers
{
    public class SettingsManager : BaseManager
    {
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
                        Value = string.Empty
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

                if (!result.Any())
                {
                    result = await InitializeSettingsAsync();
                }

                return result.Select(a => new SettingsListingResponseItem
                {
                    Description = a.HelpLabel,
                    Label = a.TitleLabel,
                    Value = a.Value
                }).ToList();
            }
        }
    }
}