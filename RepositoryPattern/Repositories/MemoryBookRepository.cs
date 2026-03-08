using RepositoryPattern.Models;

namespace RepositoryPattern.Repositories
{
    public class MemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public MemoryBookRepository()
        {
            _books = new List<Book>
            {
                new Book { BookId = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 45 },
                new Book { BookId = 2, Title = "Design Patterns", Author = "GoF", Price = 50 },
                new Book { BookId = 3, Title = "Refactoring", Author = "Martin Fowler", Price = 40 }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.BookId == id);
        }

        public void AddBook(Book book)
        {
            book.BookId = _books.Max(b => b.BookId) + 1;
            _books.Add(book);
        }

        public void DeleteBook(int id)
        {
            var book = _books.FirstOrDefault(b => b.BookId == id);
            if (book != null)
                _books.Remove(book);
        }
    }
}
