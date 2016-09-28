using System.Web.Mvc;

namespace MyEntityFrameworkLab.Controllers
{
    public class HomeController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {         
            return View();
        }
    }
}