using System;

namespace jcHAP.Objects
{
    public class TemperatureDashboardItem
    {
        public string LatestTemperature { get; set; }

        public string Location { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}