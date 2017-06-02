using System.ComponentModel.DataAnnotations.Schema;

namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class SensorData : BaseTable
    {
        [ForeignKey("SensorNodeID")]
        public SensorNodes SensorNode { get; set; }
        
        public string JSONData { get; set; }
    }
}