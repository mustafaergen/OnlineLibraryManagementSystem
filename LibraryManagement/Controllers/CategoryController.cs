using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibraryManagement.Controllers
{
    public class CategoryController : Controller
    {
        private static readonly IList<Categories> categories = new List<Categories>()
        {
        new Categories() {Id = 1, CategoryName = "Edebiyat"},
        new Categories() {Id = 2, CategoryName = "Roman"},
        new Categories() {Id = 3, CategoryName = "Tarih"},
        };

        public IActionResult Index()
        {
            ViewBag.Categories = categories;
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
