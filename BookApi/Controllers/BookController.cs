using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookApi.Entities;
using BookApi.Responses;
using BookApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookService service = new BookService();

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return service.Get();
        }


        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Object> Get(int id)
        {
            Response response = service.Get(id);
            if (response.error == null)
            {
                return Ok(response.book);
            }
            else
            {
                if (response.error.message == "IdNotFound")
                {
                    return NotFound(response.error);
                }
                else
                {
                    return BadRequest(response.error);
                }
            }
        }

        [HttpPost]
        public ActionResult<Object> Post([FromBody] Book book)
        {
            Response response = service.Post(book);
            if (response.error == null)
            {
                return Created("201", "Added Book");
            }
            else
            {
                return BadRequest(response.error);
            }
        }


        [HttpPut("{id}")]
        public ActionResult<Object> Put(int id, [FromBody] Book book)
        {
            Response response = service.Put(id, book);
            if (response.error == null)
            {
                return Ok(response.book);
            }
            else
            {
                if (response.error.message == "IdNotFound")
                {
                    return NotFound(response.error);
                }
                else
                {
                    return BadRequest(response.error);
                }
            }
        }

        [HttpDelete("{id}")]
        public ActionResult<Object> Delete(int id)
        {
            Response response = service.Delete(id);
            if (response.error == null)
            {
                return NoContent();
            }
            else
            {
                if (response.error.message == "IdNotFound")
                {
                    return NotFound(response.error);
                }
                else
                {
                    return BadRequest(response.error);
                }
            }
        }
    }
}
