using Microsoft.AspNetCore.Mvc;
using RepositoryPattern.Models;
using RepositoryPattern.Repositories;

namespace RepositoryPattern.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _repo;

        public BookController(IBookRepository repo)
        {
            _repo = repo;
        }

        public IActionResult List()
        {
            var books = _repo.GetAllBooks();
            ViewBag.RepositoryName = _repo.GetType().Name;
            return View(books);
        }

        public IActionResult Details(int id)
        {
                       var book = _repo.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repo.AddBook(book);
                return RedirectToAction("List");
            }
            return View(book);
        }

        public IActionResult Delete(int id)
        {
            _repo.DeleteBook(id);
            return RedirectToAction("List");
        }
    }
}
