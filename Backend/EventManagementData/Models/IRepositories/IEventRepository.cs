using EventManagementData.Models.Entities;

namespace EventManagementData.Models.IRepositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> GetAllEventsAsync();
        Task<Event?> GetEventByIdAsync(Guid eventGuid);
        Task<Guid> AddEventAsync(Event eventItem);
        Task<Event> UpdateEventAsync(Event eventItem);
        Task DeleteEventAsync(Guid eventGuid);
    }
}
