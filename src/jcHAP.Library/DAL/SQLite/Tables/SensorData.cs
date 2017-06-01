namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class SensorData : BaseTable
    {
        public string SensorName { get; set; }

        public string Location { get; set; }

        public string JSONData { get; set; }
    }
}