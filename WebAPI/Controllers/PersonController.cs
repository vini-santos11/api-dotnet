using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    public class PersonController : ControllerBase
    {
        private PersonService PersonService { get; }
        public PersonController(PersonService personService)
        {
            PersonService = personService;
        }

        [HttpGet("people")]
        public IActionResult Get()
        {
            return Ok(PersonService.FindAll());
        }

        [HttpGet("person/{id}")]
        public IActionResult Get(long id)
        {
            return Ok(PersonService.FindById(id));
        }

        [HttpPost("person")]
        public IActionResult Create([FromBody] Person person)
        {
            return Ok(PersonService.Create(person));
        }

        [HttpPut("person")]
        public IActionResult Update([FromBody] Person person)
        {
            if (person == null) return BadRequest();
            return Ok(PersonService.Update(person));
        }

        [HttpDelete("person/{id}")]
        public IActionResult Delete(long id)
        {
            PersonService.Delete(id);
            return NoContent();
        }
    }
}
