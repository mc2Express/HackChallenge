using System.Web.Mvc;

namespace WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return Content("");
        }
    }
}