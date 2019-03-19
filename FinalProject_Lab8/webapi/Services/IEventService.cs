using System.Collections.Generic;
using Database.Entities;

public interface IEventService
{
    List<EventDto> GetAllEvents();

    Event GetEventById(long eventId);

    void AddEvent(Event event);

    void UpdateEvent(Event event);

    void DeleteEvent(long eventId);
}