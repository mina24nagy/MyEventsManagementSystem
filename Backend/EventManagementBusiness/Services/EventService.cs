using AutoMapper;
using EventManagementBusiness.IServices;
using EventManagementBusiness.Models.Dtos;
using EventManagementBusiness.Models.ViewModels;
using EventManagementData.Models.Entities;
using EventManagementData.Models.IRepositories;

namespace EventManagementBusiness.Services
{
    public class EventService(IEventRepository eventRepository, IMapper mapper) : IEventService
    {
        public async Task<IEnumerable<EventViewModel>> GetAllEventsAsync()
        {
            var events = await eventRepository.GetAllEventsAsync();
            return mapper.Map<IEnumerable<EventViewModel>>(events);
        }

        public async Task<EventViewModel?> GetEventByIdAsync(Guid eventGuid)
        {
            var eventEntity = await eventRepository.GetEventByIdAsync(eventGuid);
            return eventEntity == null ? null : mapper.Map<EventViewModel>(eventEntity);
        }

        public async Task<Guid> AddEventAsync(EventDto eventDto)
        {
            var eventEntity = mapper.Map<Event>(eventDto);
            var createdEventGuid = await eventRepository.AddEventAsync(eventEntity);
            return createdEventGuid;
        }

        public async Task UpdateEventAsync(Guid eventGuid, EventDto eventDto)
        {
            var eventEntity = await eventRepository.GetEventByIdAsync(eventGuid);
            mapper.Map(eventDto, eventEntity);
            if (eventEntity == null) return;
            await eventRepository.UpdateEventAsync(eventEntity);
        }

        public async Task DeleteEventAsync(Guid eventGuid)
        {
            await eventRepository.DeleteEventAsync(eventGuid);
        }
    }
}
