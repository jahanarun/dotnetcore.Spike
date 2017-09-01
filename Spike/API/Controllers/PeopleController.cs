using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Context;
using API.Data.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/people")]
    public class PeopleController : Controller
    {
        private readonly SpikeContext _context;

        public PeopleController(SpikeContext context)
        {
			_context = context;

			if (_context.Peoples.Count() == 0)
			{
                _context.Peoples.Add(new People { Id = 1, Name = "Jack", Age = 22 });
				_context.SaveChanges();
			}
        }


        [HttpGet("all")]
        public IEnumerable<People> All()
        {
            return _context.Peoples;
        }

        [HttpGet("{id}", Name = "GetPeople")]
		public IActionResult GetById(int id)
		{
			var item = _context.Peoples.FirstOrDefault(t => t.Id == id);
			if (item == null)
			{
				return NotFound();
			}
			return new ObjectResult(item);
		}

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] People people)
        {
			if (people == null || people.Id != id)
			{
				return BadRequest();
			}

			var existingPeople = _context.Peoples.FirstOrDefault(x => x.Id == id);
            if(existingPeople == null)
            {
                return NotFound();
            }
            existingPeople.Age = people.Age;
            existingPeople.Name = people.Name;
            _context.SaveChanges();

            return new NoContentResult();

        }

		[HttpPost("")]
		public IActionResult Add([FromBody] People people)
		{
            if(people == null)
            {
                return BadRequest();
            }
			_context.Peoples.Add(people);
			_context.SaveChanges();
            return CreatedAtRoute("GetPeople", new { id = people.Id }, people);

		}

		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
            var match = _context.Peoples.FirstOrDefault(x => x.Id == id);
            if (match != null)
            {
                _context.Peoples.Remove(match);
                _context.SaveChanges();
                return new NoContentResult();
            }

            return NotFound();
		}
    }
}
