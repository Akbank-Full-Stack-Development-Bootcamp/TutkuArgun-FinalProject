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
    public class PublishersController : ControllerBase
    {
        private IPublisherService service;

        public PublishersController(IPublisherService publisherService)
        {
            this.service = publisherService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Get()
        {
            var result = service.GetAllPublishers();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        [AllowAnonymous]
        public IActionResult GetById(int id)
        {
            var publisherListReponse = service.GetPublisherById(id);
            if (publisherListReponse != null)
            {
                return Ok(publisherListReponse);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult AddPublisher(AddNewPublisherRequest request)
        {
            if (ModelState.IsValid)
            {
                int genreId = service.AddPublisher(request);
                return CreatedAtAction(nameof(GetById), routeValues: new { id = genreId }, value: null);
            }

            return BadRequest(ModelState);

        }
        [HttpPut("{id}")]
        public IActionResult UpdatePublisher(int id, EditPublisherRequest request)
        {
            var isExisting = service.GetPublisherById(id);
            if (isExisting == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                int newItemId = service.UpdatePublisher(request);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.DeletePublisher(id);
            return Ok();
        }
    }
}
