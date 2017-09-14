using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoLogistic.WebUI.Filters
{
    public class AjaxOrChildActionOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext == null)
                throw new ArgumentNullException("filterContext");
            if (!((filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest") ||
                  (filterContext.IsChildAction)))
                filterContext.Result = new HttpNotFoundResult();
        }
    }
}