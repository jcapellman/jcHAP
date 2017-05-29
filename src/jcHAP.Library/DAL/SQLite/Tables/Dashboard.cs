using System;

namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class Dashboard : BaseTable
    {
        public string DashboardName { get; set; }

        public DateTime LastUpdated { get; set; }

        public string JSON { get; set; }
    }
}