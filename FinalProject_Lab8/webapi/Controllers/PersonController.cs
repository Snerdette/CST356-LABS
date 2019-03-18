using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly SchoolContext _dbContext;

        public PersonController(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }
        /* 
        // GET api/values
        [HttpGet]
        public ActionResult<List<Person>> Get()
        {
            var person = _dbContext.Person
                .SingleOrDefault(p => p.PersonId == person_id);

            if (person != null) {
                return person;
            } else {
                return NotFound();
            }
        }
        */

          [HttpGet]
        public ActionResult<List<Person>> GetAllPersons()
        {
            return Ok(_dbContext.Person.ToList());
        }


        /* 
        private List<Person> getPersons(){
            return _dbContext.getPersons();
        }
        */


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
