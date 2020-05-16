using System.Web.Mvc;

namespace CarRegisterAsp.NetMVC5App.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BrandModelManagment()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Car register demo ASP.NET MVC 5 AngularJs ADO.NET web application.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page.";

            return View();
        }
    }
}