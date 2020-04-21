using System.Web.Mvc;
using System.Web.Routing;

namespace MovieShop.MVC.Filters
{
    //ActionFilter Attribute
    //Exception Filter Attribute
    //Authentication Filter Attribute
    //Authorization Filter Attribute


    //creating a custon filter to log some info about user
    //like his/her browser, type of request, url he is accessing
    public class LogActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            LogSomeInformation("OnActionExecuted", filterContext.RouteData);
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LogSomeInformation("OnActionExecuting", filterContext.RouteData);
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            LogSomeInformation("OnResultExecuted", filterContext.RouteData);
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            LogSomeInformation("OnResultExecuting", filterContext.RouteData);
        }
        private void LogSomeInformation(string methodName, RouteData routeData)
        {
            // we can log this info to any text file using any 3rd party logging  framework
            // such as Nlog, SeriLog, Log4net
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
        }

    }
}