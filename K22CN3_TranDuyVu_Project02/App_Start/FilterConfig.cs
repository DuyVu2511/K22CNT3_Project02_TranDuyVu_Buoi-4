using System.Web;
using System.Web.Mvc;

namespace K22CN3_TranDuyVu_Project02
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
