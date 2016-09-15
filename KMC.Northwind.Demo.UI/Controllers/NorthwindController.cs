using System.Configuration;
using System.Web.Mvc;

namespace KMC.Northwind.Demo.UI.Controllers
{
    public class NorthwindController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.ApiUrl = ConfigurationManager.AppSettings["ApiUrl"];
            return View();
        }
    }
}