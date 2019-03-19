using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Database;
using Database.Entities;

namespace Database.Entities
{
    
        private readonly IEventService _eventService;
        private readonly ILogger _logger;

        public EventController(IEventService eventService, ILoggerFactory loggerFactory)
        {
            _eventService = eventService;
            _logger = loggerFactory.CreateLogger("Controllers.EventController");
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<EventDto>> GetAllEvents()
        {
            return _eventService.GetAllEvents();
        }

        [HttpGet("{eventId}")]
        public ActionResult<Event> GetEvent(int eventId)
        {
            var event = _eventService.GetEventById(eventId);

            if (event != null) {
                return event;
            } else {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult<Event> AddEvent(Event event)
        {
            _eventService.AddEvent(event);

            // return CreatedAtAction(nameof(GetEvent), new { id = event.EventId }, event);

            return StatusCode(Microsoft.AspNetCore.Http.StatusCodes.Status201Created);
        }

        [HttpPut("{eventId}")]
        public ActionResult UpdateEvent(long eventId, Event eventUpdate)
        {
            eventUpdate.EventId = eventId;
            _eventService.UpdateEvent(eventUpdate);

            return NoContent();
        }

        [HttpDelete("{eventId}")]
        public ActionResult DeleteEvent(int eventId)
        {
            _eventService.DeleteEvent(eventId);

            return Ok();
        }
    }
}
