using TicketOrdering.Models;
using TicketOrdering.Repositories;

namespace TicketOrdering.Services
{
    public class TicketService
    {

        private readonly TicketRepository _repository;

        public TicketService(TicketRepository ticketRepository)
        {
            _repository = ticketRepository;
        }

        public IList<Ticket> GetAll()
        {
            return _repository.GetAll().ToArray();
        }

        public Ticket GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Ticket ticket)
        {
            _repository.Create(ticket);
        }

        public void Update()
        {}

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}