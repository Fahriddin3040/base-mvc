namespace TicketOrdering.Contracts
{
    public class ClientCreateDTO
    {
        public required string  FirstName { get; set; }

        public required string LastName { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }
    }
}