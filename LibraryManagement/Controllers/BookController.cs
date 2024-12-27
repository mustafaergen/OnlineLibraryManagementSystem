using LibraryManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        private readonly IList<Book> books;
        public BookController()
        {
            if (books == null) //Books null olduğunda liste yenilensin
            {
                books = new List<Book>()
            {
                new Book() {Id = 1, Title = "The Great Adventure", Author = "John Doe", Category = "Fiction", PublishedYear = 2005},
                new Book() {Id = 2, Title = "Science Fundamentals", Author = "Jane Smith", Category = "Science", PublishedYear = 2012},
                new Book() {Id = 3, Title = "History of the World", Author = "Peter Johnson", Category = "History", PublishedYear = 1998},
                new Book() {Id = 4, Title = "Mystery of the Unknown", Author = "Emily Davis", Category = "Mystery", PublishedYear = 2018},
                new Book() {Id = 5, Title = "Coding Essentials", Author = "Michael Brown", Category = "Technology", PublishedYear = 2021}

            };
            }
            
        }
        public IActionResult Index()
        {
            if (books != null)
                return View(books);
            else
                return BadRequest(); //Action result
        }
        [HttpGet]
        public IActionResult Create()
        {
            if (books != null)
                return View(books);
            else
                return BadRequest();
        }
        [HttpPost]
        public IActionResult Create(string title, string author, string category, int publishedYear)
        {
            books.Add(new Book() { Title = title, Author = author, Category = category, PublishedYear = publishedYear });
            return View(books); //tekrardan kitap listesini basıyoruz
        }
    }
}
