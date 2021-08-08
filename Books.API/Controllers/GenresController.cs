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
    public class GenresController : ControllerBase
    {
        private IGenreService service;

        public GenresController(IGenreService genreService)
        {
            this.service = genreService;
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllGenres();
            return Ok(result);
        }
        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var genreListReponse = service.GetGenresById(id);
            if (genreListReponse != null)
            {
                return Ok( genreListReponse);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult AddGenre(AddNewGenreRequest request)
        {
            if (ModelState.IsValid)
            {
                 int genreId = service.AddGenre(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = genreId }, value: null);
            }

            return BadRequest(ModelState);

        }

        [HttpPut("{id}")]
        [GenreExists]
        public IActionResult UpdateGenre(int id, EditGenreRequest request)
        {
            //var isExisting = service.GetGenresById(id);
            //if (isExisting == null)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                int newItemId = service.UpdateGenre(request);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        [GenreExists]
        public IActionResult Delete(int id)
        {
            service.DeleteGenre(id);
            return Ok();
        }



    }
}
