using jcHAP.Library.DAL.SQLite.Tables;

using Microsoft.EntityFrameworkCore;

namespace jcHAP.Library.DAL.SQLite
{
    public class SQLiteDAL : DbContext
    {
        public DbSet<Settings> Settings { get; set; }

        public DbSet<Dashboard> Dashboard { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Common.Constants.FILENAME_SQLITE_DB}");
        }
    }
}