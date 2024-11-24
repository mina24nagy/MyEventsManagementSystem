using EventManagementBusiness.IServices;
using EventManagementBusiness.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace EventManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController(IEventService eventService, ILogger<EventsController> logger) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            try
            {
                var events = await eventService.GetAllEventsAsync();
                if (events.Any())
                    return Ok(events);

                return NotFound();
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(GetAllEvents)}", e);
                throw;
            }
        }

        [HttpGet("{eventGuid}")]
        public async Task<IActionResult> GetEventById(Guid eventGuid)
        {
            try
            {
                var eventDto = await eventService.GetEventByIdAsync(eventGuid);
                if (eventDto == null)
                {
                    return NotFound();
                }

                return Ok(eventDto);
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(GetEventById)}", e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(EventDto eventDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdEventGuid = await eventService.AddEventAsync(eventDto);
                return Ok(createdEventGuid);
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(CreateEvent)}", e);
                throw;
            }
        }

        [HttpPut("{eventGuid}")]
        public async Task<IActionResult> UpdateEvent(Guid eventGuid, EventDto eventDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var eventItem = await eventService.GetEventByIdAsync(eventGuid);
                if (eventItem == null)
                    return NotFound();

                await eventService.UpdateEventAsync(eventGuid, eventDto);
                return Ok(new { message = "Event updated successfully" });
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(UpdateEvent)}", e);
                throw;
            }
        }

        [HttpDelete("{eventGuid}")]
        public async Task<IActionResult> DeleteEvent(Guid eventGuid)
        {
            try
            {
                var eventItem = await eventService.GetEventByIdAsync(eventGuid);
                if (eventItem == null)
                    return NotFound();

                await eventService.DeleteEventAsync(eventGuid);
                return Ok(new { message = "Event deleted successfully" });
            }
            catch (Exception e)
            {
                logger.LogError($"Error in {nameof(DeleteEvent)}", e);
                throw;
            }
        }
    }
}
