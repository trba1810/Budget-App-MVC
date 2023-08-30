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

        [HttpGet]
        public IActionResult CreateWindow()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Create(category);
            return RedirectToAction("Index",category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id,Category category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }
            try
            {
                _categoryRepository.Update(category);
            }
            catch
            {
                return BadRequest();
            }
            return RedirectToAction("Index");
        }

        [HttpGet("[action]/{id}")]
        public IActionResult DeleteWindowCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }

            return View("Delete", category);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.GetCategory(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryRepository.Delete(category);
            return RedirectToAction("Index");
        }
    }
}
