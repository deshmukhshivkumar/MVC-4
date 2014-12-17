using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using MvcAppVs2013.Filters;

namespace MvcAppVs2013.Controllers
{

    public class HomeController : Controller
    {
        [OutputCache(Duration = 20)]
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application. " + DateTime.Now;

            return View();
        }

        [Authorize]
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [Log]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Demo()
        {
            return View();
        }

        public ActionResult Razor()
        {
            return View();
            //return View("RazorBasics");
        }

        public ActionResult ActionReturns()
        {
            return View("ActionBasics");
        }

        public ContentResult Content()
        {
            return Content("This is some content");
        }

        public JsonResult JsomResult()
        {
            var result = new { Id = "1", Name = "Some Name" };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public FileResult GetStyleSheet()
        {
            return File("~/Content/Site.css", "Text/Css");
        }

        public HttpUnauthorizedResult UnauthorizedResult()
        {
            return new HttpUnauthorizedResult();

            #region defineLoginPage
            //<authentication mode="Forms">
            //   <forms loginUrl="~/Authenticate/SignIn" timeout="2880"/>    
            //</authentication>
            #endregion
        }

    }
}
