namespace TicketOrdering.Models
{
    public class Client
    {
        public int Id { get; set; }

        public required string  FirstName { get; set; }

        public required string LastName { get; set; }

        public IList<Ticket?>? Tickets { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }
}