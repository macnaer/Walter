using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Walter.Core.DTO_s.Category;
using Walter.Core.Interfaces;

namespace Walter.Web.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly ICategoryService _categoryService;

        public PostController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create()
        {
            await LoadCategories();
            return View();
        }

        private async Task LoadCategories()
        {
            ViewBag.CategoryList = new SelectList(
                await _categoryService.GettAll(),
                nameof(CategoryDto.Id),
                nameof(CategoryDto.Name)
                );
            ;
        }
    }
}
