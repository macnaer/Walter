using Microsoft.AspNetCore.Mvc;

namespace Walter.Web.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
