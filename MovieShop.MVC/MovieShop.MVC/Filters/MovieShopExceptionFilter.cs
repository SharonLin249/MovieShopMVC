using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieShop.MVC.Filters
{


	public class MovieShopExceptionFilter : HandleErrorAttribute
	{ 
		public override void OnException(ExceptionContext filterContext)
		{
			//When exception happens what should our application do?
			//• You need to catch the exception
			//	○ Get the exception details such as exception type
			//	○ Exception message
			//	○ Any inner exception
			//	○ StackTrace
			//	○ Date Time when exception happened
			//	○ For which user exception happened
			//	○ Browser which user is using when exception happened
			//• Log those exception, usually we log them in text files, sometimes DB but its rare
			//	○ We can use any popular 3rd party logging frameworks to log the exception
			//		§ Nlog
			//		§ SeriLog
			//		§ Log4Net
			//	○ Download those from nuget
			//• Send emails when exception happens to the Development Team
			//• Always show a friendly error page to the user

			var controllerName = (string)filterContext.RouteData.Values["controller"];
			var actionName = (string)filterContext.RouteData.Values["action"];
			base.OnException(filterContext);

			//create a Model for HandleErrorInfo, which is already built-in mvc
			var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

			var dateTimeExceptionHappened = DateTime.Now.TimeOfDay.ToString();
			var stackTrace = filterContext.Exception.StackTrace;
			var exceptionMessage = filterContext.Exception.Message;
			var innerException = filterContext.Exception.InnerException;

			//show info of the error view
			filterContext.Result = new ViewResult
			{
				ViewName = View,
				MasterName = Master,
				ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
				TempData = filterContext.Controller.TempData
			};
			//exception has been handled,
			filterContext.ExceptionHandled = true;
			filterContext.HttpContext.Response.Clear();
			//nothing is shown, since has been handled
			filterContext.HttpContext.Response.StatusCode = 500;
			// Http Status Code 500 should be used when and exception happens
			filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
			// Now use NLog to log above details to the Text Files. 
			base.OnException(filterContext);

		}
    }
}