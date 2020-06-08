using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PeopleController : ControllerBase
	{
		// set up some test data
		private static readonly List<Person> _people = new List<Person>
		{
			new Person
			{
				Id = 1,
				Name = "Luke Skywalker",
				HairColor = "blond"
			},

			new Person
			{
				Id = 5,
				Name = "Leia Organa",
				HairColor = "brown"
			}
		 };

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return Ok(_people); // return the whole list of people

		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			var person = _people.FirstOrDefault(p => p.Id == id);
			if (person == null) return NotFound();
			return Ok(person);
		}

		// POST api/values
		[HttpPost]
		public IActionResult Post([FromBody] Person newPerson)
		{
			_people.Add(newPerson);
			return CreatedAtAction("Get", newPerson, new { id = new Random().Next() });
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
