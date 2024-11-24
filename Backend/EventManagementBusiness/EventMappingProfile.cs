using EventManagementBusiness.Models.Dtos;
using EventManagementBusiness.Models.ViewModels;
using AutoMapper;
using EventManagementData.Models.Entities;

namespace EventManagementBusiness
{
    public class EventMappingProfile : Profile
    {
        public EventMappingProfile()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<Event, EventViewModel>();
        }
    }
}
