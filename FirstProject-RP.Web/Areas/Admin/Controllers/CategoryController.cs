using CodeYad_Blog.CoreLayer.Utilities;
using FirstProject_RP.Web.Areas.Admin.Models.Categories;
using FirtsProject_RP.CoreLayer.DTOs.Categories;
using FirtsProject_RP.CoreLayer.Services.Categories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace FirstProject_RP.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }


        public IActionResult Index()
        {
            return View(_categoryService.GetAllCategory());
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(CreateCategoryViewModel createCategoryViewModel)
        {

            var result = _categoryService.CreateCategory(createCategoryViewModel.MapToDto());
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(createCategoryViewModel.Slug), result.Message);
                return View();
            }
            return RedirectToAction("Index");



        }


        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetCategoryBy(id);
            if (category == null)
                return RedirectToAction("Index");

            var model = new EditCategoryViewModel()
            {
                MetaDescription = category.MetaDescription,
                Slug = category.Slug,
                MetaTag = category.MetaTag,
                Title = category.Title,
                
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, EditCategoryViewModel editModel)
        {
            var result = _categoryService.EditCategory(new EditCategoryDto()
            {
                Slug = editModel.Slug,
                MetaDescription = editModel.MetaDescription,
                MetaTag = editModel.MetaTag,
                Title = editModel.Title,    
                Id = id

            });
            if (result.Status != OperationResultStatus.Success)
            {
                ModelState.AddModelError(nameof(editModel.Slug),result.Message);
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
