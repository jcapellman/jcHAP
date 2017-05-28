using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using jcHAP.Library.DAL.SQLite;
using jcHAP.Library.Objects.Settings;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.Managers
{
    public class SettingsManager : BaseManager
    {
        public async Task<List<SettingsListingResponseItem>> LoadSettings()
        {
            using (var dbFactory = new SQLiteDAL())
            {
                var result = await dbFactory.Settings.ToListAsync();

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