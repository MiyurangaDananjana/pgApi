using Microsoft.AspNetCore.Mvc;
using PsSQL.Models.DTOs;
using PsSQL.Models.Entities;
using PsSQL.Services;

namespace PsSQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly List<BooksModel> books = new List<BooksModel>
        {
            new BooksModel { BookId = 1, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Year = "1925" },
            new BooksModel { BookId = 2, Title = "Pride and Prejudice", Author = "Jane Austen", Year = "1813" },
            new BooksModel { BookId = 3, Title = "The Catcher in the Rye", Author = "J.D. Salinger", Year = "1951" },
            new BooksModel { BookId = 4, Title = "Moby-Dick", Author = "Herman Melville", Year = "1851" },
            new BooksModel { BookId = 5, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Year = "1954" },
            new BooksModel { BookId = 6, Title = "One Hundred Years of Solitude", Author = "Gabriel García Márquez", Year = "1967" },
            new BooksModel { BookId = 7, Title = "The Chronicles of Narnia", Author = "C.S. Lewis", Year = "1950" },
            new BooksModel { BookId = 8, Title = "Brave New World", Author = "Aldous Huxley", Year = "1932" },
            new BooksModel { BookId = 9, Title = "The Alchemist", Author = "Paulo Coelho", Year = "1988" },
            new BooksModel { BookId = 10, Title = "To Kill a Mockingbird", Author = "Harper Lee", Year = "1960" },
            new BooksModel { BookId = 11, Title = "1984", Author = "George Orwell", Year = "1949" },
            new BooksModel { BookId = 12, Title = "Anna Karenina", Author = "Leo Tolstoy", Year = "1877" },
            new BooksModel { BookId = 13, Title = "The Hobbit", Author = "J.R.R. Tolkien", Year = "1937" },
            new BooksModel { BookId = 14, Title = "Crime and Punishment", Author = "Fyodor Dostoevsky", Year = "1866" },
            new BooksModel { BookId = 15, Title = "The Odyssey", Author = "Homer", Year = "8th century BCE" },
            new BooksModel { BookId = 16, Title = "The Shining", Author = "Stephen King", Year = "1977" },
            new BooksModel { BookId = 17, Title = "The Grapes of Wrath", Author = "John Steinbeck", Year = "1939" },
            new BooksModel { BookId = 18, Title = "Frankenstein", Author = "Mary Shelley", Year = "1818" },
            new BooksModel { BookId = 19, Title = "The Picture of Dorian Gray", Author = "Oscar Wilde", Year = "1890" },
            new BooksModel { BookId = 20, Title = "The Hunger Games", Author = "Suzanne Collins", Year = "2008" }
        };

        private readonly JsonDataService _jsonDataService;

        public BooksController(JsonDataService jsonDataService)
        {
            _jsonDataService = jsonDataService;
        }

        [HttpGet("get-books-details")]
        public IActionResult GetBooks(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                return Ok(books.Take(10));
            }

            var filteredBooks = books
              .Where(b => b.Title != null && b.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
              .Take(10)  // Take the first 10 filtered books
              .ToList();


            return Ok(filteredBooks);
        }


        [HttpGet("get-book-data")]
        public IActionResult GetBookData(int id)
        {
            var book = books.FirstOrDefault(b => b.BookId == id);

            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound(); 
            }
        }

        [HttpGet("getBooks")]
        public IActionResult GetBooks()
        {
            List<BookModel>? books = _jsonDataService.GetBooks();

            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("search/{title}")]
        public IActionResult SearchByTitle(string title)
        {
            List<BookModel>? books = _jsonDataService.GetBooks();
            var result = books.FindAll(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
            return Ok(result);
        }
    }
}
