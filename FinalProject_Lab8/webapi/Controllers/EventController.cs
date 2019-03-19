using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;

namespace Database.Entities
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {

        private readonly WorkContext _dbContext;

        public EventController(WorkContext dbContext)
        {
            _dbContext = dbContext;
        }
       
         [HttpGet]
        public ActionResult<List<Event>> GetAllEvents()
        {
            return Ok(_dbContext.Event.ToList());
        }

        /* 
         public ActionResult<Event> getSpecial(int id)
        {
             var event = _dbContext.getEvent(id);

            if (event != null) {
                return event;
            } 
            return event;
        }*/

         public ActionResult<int> getEventCount(Event event)
        {
            return Event.EventCount;
        }

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
