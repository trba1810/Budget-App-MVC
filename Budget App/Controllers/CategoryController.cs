using Budget_App.Models;
using Budget_App.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Budget_App.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_categoryRepository.GetCategories());
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Create(category);
            return RedirectToAction("Index");
        }
    }
}
