using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Database.Entities;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRespository;
    private readonly ILogger _logger;

    public EventService(IEventRepository eventRepository, ILoggerFactory loggerFactory)
    {
        _eventRespository = eventRepository;
        _logger = loggerFactory.CreateLogger("Controllers.EventService");
    }

    public List<EventDto> GetAllEvents()
    {
        var eventDtos = new List<EventDto>();

        foreach(var event in _eventRespository.GetAllEvents())
        {
            eventDtos.Add(new EventDto {
                EventId = event.EventId,
                Name = event.Name,
                Location = event.Location
            });
            if (BusinessRules.isLowInventory(event))
            {
                _logger.LogInformation("Found low inventory event: " + event.EventId);
            }
        }

        return eventDtos;
    }

    public Event GetEventById(long eventId)
    {
        return _eventRespository.GetEventById(eventId);
    }

    public void AddEvent(Event event)
    {
        _eventRespository.AddEvent(event);
    }

    public void UpdateEvent(Event event)
    {
        _eventRespository.UpdateEvent(event);
    }

    public void DeleteEvent(long eventId)
    {
        _eventRespository.DeleteEvent(eventId);
    }
}