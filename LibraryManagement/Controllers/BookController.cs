using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private static readonly IList<Book> books = new List<Book>()
        {
                new Book() {Id = 1, Title = "Tutunamayanlar", Author = "Oğuz Atay", Category = "Edebiyat", PublishedYear = 1971},
                new Book() {Id = 2, Title = "Kürk Mantolu Madonna", Author = "Sabahattin Ali", Category = "Roman", PublishedYear = 1943},
                new Book() {Id = 3, Title = "İnce Memed", Author = "Yaşar Kemal", Category = "Roman", PublishedYear = 1955},
                new Book() {Id = 4, Title = "Saatleri Ayarlama Enstitüsü", Author = "Ahmet Hamdi Tanpınar", Category = "Edebiyat", PublishedYear = 1962},
                new Book() {Id = 5, Title = "Çalıkuşu", Author = "Reşat Nuri Güntekin", Category = "Roman", PublishedYear = 1922},
                new Book() {Id = 6, Title = "Hayvan Çiftliği", Author = "George Orwell", Category = "Politik", PublishedYear = 1945},
                new Book() {Id = 7, Title = "Cumhuriyetin Felsefi Temelleri", Author = "İsmail Hakkı Akyüz", Category = "Tarih", PublishedYear = 2005}
        };
        private static readonly IList<Categories> categories = new List<Categories>()
        {
            new Categories() {Id=1,CategoryName="Edebiyat"},
            new Categories() {Id=2,CategoryName="Roman"},
            new Categories() {Id=3,CategoryName="Tarih"},
        };
        public BookController()
        {
        }
        public IActionResult Index(string category)
        {
            ViewBag.Categories = categories;
            var booksList = string.IsNullOrEmpty(category) ? books : books.Where(b => b.Category == category).ToList();
            return View(booksList);

        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(Book book)
        {

            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {

                TempData["ErrorMessage"] = "A book with the same ID already exists.";
                return View(book);
            }
            books.Add(book);
            TempData["SuccessMessage"] = "Book added successfully!";
            return RedirectToAction("Index"); // Kitap listesine yönlendir
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = books.FirstOrDefault(book => book.Id == id);
            if (book != null)
                return View(book);
            else
                return NotFound();
        }
        [HttpPost]
        public IActionResult Edit(Book model)
        {
            var book = books.FirstOrDefault(b => b.Id == model.Id);
            book.Author = model.Author;
            book.PublishedYear = model.PublishedYear;
            book.Title = model.Title;
            book.Category = model.Category;
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var deletedBook = books.FirstOrDefault(x => x.Id == id);
            books.Remove(deletedBook);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var book = books.FirstOrDefault(x => x.Id == id);
            return View(book);
        }
    }
}
