using System;

namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class BaseTable
    {
        public int ID { get; set; }

        public DateTime Modified { get; set; }

        public DateTime Created { get; set; }

        public bool Active { get; set; }
    }
}