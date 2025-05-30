namespace RegistrationAPI.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string AttendeeName { get; set; }
        public string AttendeeEmail { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}