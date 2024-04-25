using System.Text.Json.Serialization;

namespace TicketOrdering.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        public required string Title { get; set; }

        public int OwnerId { get; set; }

        [JsonIgnore]
        public Client? Owner { get; set; }
    }
}