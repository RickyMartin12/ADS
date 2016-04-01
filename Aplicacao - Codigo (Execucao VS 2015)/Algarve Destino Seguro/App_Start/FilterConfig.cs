using System.Web;
using System.Web.Mvc;

namespace Algarve_Destino_Seguro
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
