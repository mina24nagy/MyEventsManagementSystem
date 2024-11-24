using EventManagementData.Models.Entities;
using EventManagementData.Models.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace EventManagementData.Models.Repositories
{
    public class EventRepository(EventDbContext context) : IEventRepository
    {
        public async Task<IEnumerable<Event>> GetAllEventsAsync()
        {
            return await context.Events.ToListAsync();
        }

        public async Task<Event?> GetEventByIdAsync(Guid id)
        {
            return await context.Events.FindAsync(id);
        }

        public async Task<Guid> AddEventAsync(Event eventItem)
        {
            context.Events.Add(eventItem);
            await context.SaveChangesAsync();
            return eventItem.EventId;
        }

        public async Task<Event> UpdateEventAsync(Event eventItem)
        {
            context.Events.Update(eventItem);
            await context.SaveChangesAsync();
            return eventItem;
        }

        public async Task DeleteEventAsync(Guid id)
        {
            var eventToDelete = await context.Events.FindAsync(id);
            if (eventToDelete != null)
            {
                context.Events.Remove(eventToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
