using Microsoft.AspNetCore.Mvc;

namespace Vendors.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }
    }
}
