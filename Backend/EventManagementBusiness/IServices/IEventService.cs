using EventManagementBusiness.Models.Dtos;
using EventManagementBusiness.Models.ViewModels;

namespace EventManagementBusiness.IServices
{
    public interface IEventService
    {
        Task<IEnumerable<EventViewModel>> GetAllEventsAsync();
        Task<EventViewModel?> GetEventByIdAsync(Guid eventGuid);
        Task<Guid> AddEventAsync(EventDto eventDto);
        Task UpdateEventAsync(Guid eventGuid, EventDto eventDto);
        Task DeleteEventAsync(Guid eventGuid);
    }
}
