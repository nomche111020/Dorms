using System.Web;
using System.Web.Mvc;

namespace Proekt_Studentski_Studentski_Domovi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
