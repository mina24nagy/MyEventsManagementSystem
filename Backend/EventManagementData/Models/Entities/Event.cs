using System.ComponentModel.DataAnnotations;

namespace EventManagementData.Models.Entities
{
    public class Event
    {
        [Key]
        public Guid EventId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required DateTime StartDate { get; set; }
        public required DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
    }
}
