using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Walter.Core.DTO_s.Category;
using Walter.Core.DTO_s.Post;
using Walter.Core.Interfaces;
using Walter.Core.Validation.Category;
using X.PagedList;

namespace Walter.Web.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;

        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;

        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GettAll());
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryDto model)
        {
            var validator = new CreateValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                var result = await _categoryService.GetByName(model);
                if (!result.Success)
                {
                    ViewBag.AuthError = "Category exists.";
                    return View(model);
                }
                await _categoryService.Create(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthError = validationResult.Errors[0];
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDto = await _categoryService.Get(id);

            if (categoryDto == null)
            {
                ViewBag.AuthError = "Category not found.";
                return View();
            }
            return View(categoryDto);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryDto model) // 1-FromForm, 2-FromRoute, 
        {
            var validator = new CreateValidation();
            var validationResult = await validator.ValidateAsync(model);
            if (validationResult.IsValid)
            {
                await _categoryService.Update(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.AuthError = validationResult.Errors[0];
            return View(model);
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDto = await _categoryService.Get(id);

            if (categoryDto == null)
            {
                ViewBag.AuthError = "Category not found.";
                return View();
            }

            List<PostDto> posts = await _postService.GetByCategory(id);
            ViewBag.CategoryName = categoryDto.Name;
            ViewBag.CategoryId = categoryDto.Id;

            int pageSize = 20;
            int pageNumber = 1;
            return View("Delete", posts.ToPagedList(pageNumber, pageSize));
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var categoryDto = await _categoryService.Get(id);
            if (categoryDto == null)
            {
                ViewBag.AuthError = "Category not found.";
                return View();
            }
            await _categoryService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
