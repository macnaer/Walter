using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walter.Core.DTO_s.User;

namespace Walter.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous] // Method GET
        public async Task<IActionResult> SignIn()
        {
            return View();
        }


        [AllowAnonymous] // Method POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(LoginUserDto model)
        {
            return View();
        }

    }
}
