using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walter.Core.DTO_s.User;
using Walter.Core.Validation.User;

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
            var validator = new LoginUserValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                return View();
            }
            ViewBag.AuthError = validationResult.Errors[0];
            return View(model);
        }

    }
}
