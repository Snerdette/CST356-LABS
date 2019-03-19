using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Database;
using Database.Entities;
using System;

public class EventRepository : IEventRepository
{
    private readonly WorkContext _dbContext;
    private readonly ILogger _logger;

    public EventRepository(WorkContext dbContext, ILoggerFactory loggerFactory)
    {
        _dbContext = dbContext;
        _logger = loggerFactory.CreateLogger("Controllers.EventRepository");
    }

    public List<Event> GetAllEvents()
    {
        try
        {
            return _dbContext.Event.ToList();
        } 
        catch(Exception ex)
        {
            _logger.LogError("Failed to get events.", ex);
            
            return new List<Event>();
        }
    }

    public Event GetEventById(long eventId)
    {
        return _dbContext.Event.SingleOrDefault(p => p.EventId == eventId);
    }

    public void AddEvent(Event event)
    {
        _dbContext.Event.AddEvent(event);
        _dbContext.SaveChanges();
    }

    public void UpdateEvent(Event eventUpdate)
    {
        var event = GetEventById(eventUpdate.EventId);

        if (event != null)
        {
            event.Name = eventUpdate.Name;
            event.Location = eventUpdate.Location;
            event.startTime = eventUpdate.StartTime;

            event.endTime = eventUpdate.EndTime;

            _dbContext.Update(event);

            _dbContext.SaveChanges();
        }
    }

    public void DeleteEvent(long eventId)
    {
        var event = new Event { EventId = eventId };

        _dbContext.Event.Attach(event);
        _dbContext.Event.Remove(event);
        _dbContext.SaveChanges();
    }
}