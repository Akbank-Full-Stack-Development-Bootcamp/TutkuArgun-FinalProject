using Books.API.Filters;
using Books.Business;
using Books.Business.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AuthorsController : ControllerBase
    {
        private IAuthorService service;


        public AuthorsController(IAuthorService authorService)
        {
            this.service = authorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllAuthors();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var authorListReponse = service.GetAuthorById(id);
            if (authorListReponse != null)
            {
                return Ok(authorListReponse);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddAuthor(AddNewAuthorRequest request)
        {
            if (ModelState.IsValid)
            {
                int authorId = service.AddAuthor(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = authorId }, value: null);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        [AuthorExists]
        public IActionResult UpdateAuthor(int id, EditAuthorRequest request)
        {
            //var isExisting = service.GetAuthorById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateAuthor(request);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [AuthorExists]
        public IActionResult Delete(int id)
        {
            service.DeleteAuthor(id);
            return Ok();
        }

    }
}
