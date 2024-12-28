using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private static readonly IList<Book> books = new List<Book>() 
        {
                new Book() {Id = 1, Title = "The Great Adventure", Author = "John Doe", Category = "Fiction", PublishedYear = 2005},
                new Book() {Id = 2, Title = "Science Fundamentals", Author = "Jane Smith", Category = "Science", PublishedYear = 2012},
                new Book() {Id = 3, Title = "History of the World", Author = "Peter Johnson", Category = "History", PublishedYear = 1998},
                new Book() {Id = 4, Title = "Mystery of the Unknown", Author = "Emily Davis", Category = "Mystery", PublishedYear = 2018},
                new Book() {Id = 5, Title = "Coding Essentials", Author = "Michael Brown", Category = "Technology", PublishedYear = 2021}
        };
        public BookController()
        {
        }
        public IActionResult Index()
        {
            return View(books);
        }
        [HttpGet]
        public IActionResult Create()
        { 
            return View();
           
        }
        [HttpPost]
        public IActionResult Create(Book book)
        {
            books.Add(book);
            return RedirectToAction("Index"); //tekrardan kitap listesini basıyoruz
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
            var book = books.FirstOrDefault(b=>b.Id==model.Id);
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
            var book = books.FirstOrDefault(x=>x.Id == id);
            return View(book);
        }
    }
}
