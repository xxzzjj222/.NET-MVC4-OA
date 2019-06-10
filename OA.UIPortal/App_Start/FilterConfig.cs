using OA.UIPortal.Models;
using System.Web;
using System.Web.Mvc;

namespace OA.UIPortal
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new MyExceptionFilterAttribute());
            filters.Add(new LoginVerifyFilterAttribute() { IsCheck=true});
        }
    }
}