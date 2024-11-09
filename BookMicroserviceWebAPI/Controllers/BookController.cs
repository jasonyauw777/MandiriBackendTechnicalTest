using Microsoft.AspNetCore.Mvc;
using BookMicroserviceWebAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace BookMicroserviceWebAPI.Controllers
{
    // CRUD FUNCTIONS
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly ILogger<BookController> _logger;
        private readonly IBookService _bookService;

        public BookController(ILogger<BookController> logger, IBookService bookService)
        {
            _logger = logger;
            _bookService = bookService;
        }

        // READ
        [Route("GetBooks")]
        [HttpGet, AllowAnonymous]
        public IActionResult GetBooks() 
        {
            try
            {   
                var Books = _bookService.GetBooks();
                var jsonData = new 
                {
                    Books = Books,
                    Status = true,
                    Message = "Get Books Success"
                };

                return new JsonResult(jsonData);

            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        // CREATE
        [Route("AddBook")]
        [HttpPost, AllowAnonymous]
        public IActionResult AddBook([FromBody] Requests.Book.BookRequests reqParam)
        {
            try
            {
                _bookService.AddBook(reqParam.Title, reqParam.Author);
                var jsonData = new
                {
                    Status = true,
                    Message = "Add Book Success"
                };

                return new JsonResult(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // UPDATE
        [Route("UpdateBook")]
        [HttpPut, AllowAnonymous]
        public IActionResult UpdateBook([FromBody] Requests.Book.UpdateBookRequests reqParam)
        {
            try
            {
                _bookService.UpdateBook(reqParam.Id, reqParam.Title, reqParam.Author);
                var jsonData = new
                {
                    Status = true,
                    Message = "Update Book Success"
                };

                return new JsonResult(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE
        [Route("DeleteBook")]
        [HttpDelete, AllowAnonymous]
        public IActionResult DeleteBook([FromBody] Requests.Book.DeleteBookRequest reqParam)
        {
            try
            {
                _bookService.DeleteBook(reqParam.Id);
                var jsonData = new
                {
                    Status = true,
                    Message = "Delete Book Success"
                };

                return new JsonResult(jsonData);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}

