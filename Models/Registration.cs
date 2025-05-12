namespace RegistrationApi.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public string ParticipantName { get; set; }
        public string Email { get; set; }
        public int EventId { get; set; }
    }
}
