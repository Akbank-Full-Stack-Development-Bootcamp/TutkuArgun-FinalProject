using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private IBookService service;

        public BooksController(IBookService bookService)
        {
            this.service = bookService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = service.GetAllBooks();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var bookListResponse = service.GetBookById(id);
            if (bookListResponse != null)
            {
                return Ok(bookListResponse);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddBook(AddNewBookRequest request)
        {
            if (ModelState.IsValid)
            {
                int bookId = service.AddBook(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = bookId }, value: null);
            }

            return BadRequest(ModelState);

        }

    }
}
