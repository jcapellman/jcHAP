using jcHAP.Library.Enums;

namespace jcHAP.Library.DAL.SQLite.Tables
{
    public class Settings : BaseTable
    {
        public string TitleLabel { get; set; }

        public string HelpLabel { get; set; }

        public string Value { get; set; }

        public FieldType SettingsFieldType { get; set; }
    }
}