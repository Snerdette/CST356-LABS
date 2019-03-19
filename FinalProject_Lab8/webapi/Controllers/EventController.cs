using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;
using Database.Entities;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventController : ControllerBase
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
            _logger.LogDebug("Getting all events");
            // return Ok(_dbContext.Event.Include(p => p.Manufacturer).ToList());

            return _eventService.GetAllEvents();
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<EventDto>> GetEventById()
        {
            _logger.LogDebug("Getting all events");
            // return Ok(_dbContext.Event.Include(p => p.Manufacturer).ToList());

            return _eventService.GetAllEvents();
        }
        /* 
        [HttpGet("{productId}")]
        public ActionResult<Event> GetEventById(int eventId)
        {
            var event = _eventService.GetEventById(eventId);

            if (event != null) {
                return event;
            } else {
                return NotFound();
            }
        }

        */
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