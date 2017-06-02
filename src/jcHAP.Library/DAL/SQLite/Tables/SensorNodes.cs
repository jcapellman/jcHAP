using System;

namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class SensorNodes : BaseTable
    {
        public string Location { get; set; }

        public bool Enabled { get; set; }

        public DateTime? LastReportedDate { get; set; }
        
        public string LastReportedData { get; set; }
    }
}