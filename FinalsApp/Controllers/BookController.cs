using FinalsApp.models;
using Microsoft.AspNetCore.Mvc;

namespace FinalsApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly BookDbContext _dbContext;
        public BookController(BookDbContext BookDbContext)
        {
            this._dbContext = BookDbContext;
        }

        [HttpGet]
        public IActionResult GetAllBook()
        {
            return Ok(_dbContext.Books.ToList());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult GetBookByID([FromRoute] Guid id)
        {
            var Book = _dbContext.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }
            return Ok(Book);
        }


        [HttpPost]
        public IActionResult AddBook(BookPostRequest request)
        {
            var Book = new Book()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Author = request.Author,
                Price = request.Price
            };

            _dbContext.Books.Add(Book);
            _dbContext.SaveChanges();

            return Ok(Book);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public IActionResult UpdateBook([FromRoute] Guid id, BookPutRequest request)
        {
            var Book = _dbContext.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }
            else
            {
                Book.Title = request.Title;
                Book.Author = request.Author;
                Book.Price = request.Price;
                _dbContext.SaveChanges();
                return Ok(Book);
            }
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteBook([FromRoute] Guid id)
        {
            var Book = _dbContext.Books.Find(id);
            if (Book == null)
            {
                return NotFound();
            }
            else
            {
                _dbContext.Books.Remove(Book);
                _dbContext.SaveChanges();
                return Ok("Book is deleted");
            }
        }
    }
}