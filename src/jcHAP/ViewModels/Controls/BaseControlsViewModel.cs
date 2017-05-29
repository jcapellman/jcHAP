using System.Linq;

using jcHAP.Library.DAL.SQLite;

using Newtonsoft.Json;

namespace jcHAP.ViewModels.Controls
{
    public abstract class BaseControlsViewModel : BaseViewModel
    {
        protected abstract string GetName();

        protected T getData<T>()
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