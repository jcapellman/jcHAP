using jcHAP.Library.DAL.SQLite;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.Managers
{
    public class InitManager : BaseManager
    {
        public async void InitializePlatform()
        {
            using (var db = new SQLiteDAL())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}