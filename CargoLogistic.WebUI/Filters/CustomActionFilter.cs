using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CargoLogistic.WebUI.Filters
{
    public class CustomActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //ActionLog log
            base.OnActionExecuting(filterContext);

        }
    }
}