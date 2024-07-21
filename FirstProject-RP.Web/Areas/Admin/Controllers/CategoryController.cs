using FirtsProject_RP.CoreLayer.Services.Categories;
using Microsoft.AspNetCore.Mvc;

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
    }
}
