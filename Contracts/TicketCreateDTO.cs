using TicketOrdering.Models;

namespace TicketOrdering.Contracts
{
    public class TicketCreateDTO
    {
        public required string Title { get; set; }

        public int OwnerId { get; set; }

    }
}