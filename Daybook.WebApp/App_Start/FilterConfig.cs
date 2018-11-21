using System.Web.Mvc;

namespace Daybook.WebApp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //filters.Add(new CustomRequireHttpsFilter());
        }
    }
}
