using System.Linq;

using jcHAP.Library.DAL.SQLite;

namespace jcHAP.ViewModels.Controls
{
    public class BaseControlsViewModel : BaseViewModel
    {
        private abstract string GetName();

        private T getData<T>()
        {
            using (var db = new SQLiteDAL())
            {
                var data = db.Dashboard.FirstOrDefault(a => a.DashboardName == GetName());

                if (data == null)
                {
                    return default(T);
                }

                return (T)JsonConvert.DeserializeObject(data.JSON);
            }
        }
    }
}