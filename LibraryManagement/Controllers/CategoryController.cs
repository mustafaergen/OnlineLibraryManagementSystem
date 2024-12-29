using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly IList<Categories> categories = new List<Categories>()
        {
        new Categories() { Id = 1, CategoryName = "Edebiyat", Description = "Edebiyat ve sanatla ilgili kitaplar." },
        new Categories() { Id = 2, CategoryName = "Roman", Description = "Kurgu ve hikaye anlatan kitaplar." },
        new Categories() { Id = 3, CategoryName = "Tarih", Description = "Geçmiş olaylar ve tarihsel gelişmelerle ilgili kitaplar." },
        new Categories() { Id = 4, CategoryName = "Politik", Description = "Siyaset, yönetim ve toplumsal düzenle ilgili kitaplar." },

        };

        public IActionResult Index()
        {
            ViewBag.Categories = categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories category)
        {
            var existingCategory = categories.FirstOrDefault(x => x.Id == category.Id);
            if(existingCategory !=null)
            {
                TempData["ErrorMessage"] = "ID already exists.";
                return View(category);
            }
            categories.Add(category);
            TempData["SuccessMessage"] = "Category added successfuly";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = categories.FirstOrDefault(cat => cat.Id == id);
            if (category != null)
                return View(category);
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Categories model)
        {
            var category = categories.FirstOrDefault(c => c.Id == model.Id);
            category.CategoryName = model.CategoryName;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedCategory = categories.FirstOrDefault(x => x.Id == id);
            categories.Remove(deletedCategory);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);
            return View(category);
        }
    }
}
