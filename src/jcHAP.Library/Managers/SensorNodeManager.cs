using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using jcHAP.Library.DAL.SQLite;
using jcHAP.Library.DAL.SQLite.Tables;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.Managers
{
    public class SensorNodeManager : BaseManager
    {
        public async void AddSensorNode(string location)
        {
            using (var db = new SQLiteDAL())
            {
                var item = new SensorNodes
                {
                    Location = location
                };

                await db.SensorNodes.AddAsync(item);

                await db.SaveChangesAsync();
            }
        }

        public async Task<List<SensorNodes>> GetSensorNodes()
        {
            using (var db = new SQLiteDAL())
            {
                return await db.SensorNodes.Where(a => a.Active).ToListAsync();
            }
        }
    }
}