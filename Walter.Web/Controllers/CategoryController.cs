using Microsoft.AspNetCore.Mvc;
using Walter.Core.Interfaces;

namespace Walter.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GettAll());
        }
    }
}
