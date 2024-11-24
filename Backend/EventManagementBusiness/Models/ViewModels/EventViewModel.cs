namespace EventManagementBusiness.Models.ViewModels
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? Location { get; set; }
        public int Capacity { get; set; }
    }
}
