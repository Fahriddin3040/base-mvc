using TicketOrdering.Data;
using TicketOrdering.Models;

namespace TicketOrdering.Repositories
{
    public class TicketRepository
    {
        private readonly ApplicationDbContext _context; 

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Ticket> GetAll()
        {
            return _context.Tickets;
        }

        public Ticket GetById(int id)
        {
            return _context.Tickets.SingleOrDefault(cl => cl.Id == id)!;
        }

        public void Create(Ticket Ticket)
        {
            _context.Tickets.Add(Ticket);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            var Ticket = GetById(id);
            _context.Tickets.Update(Ticket);
        }

        public void Delete(int id)
        {
            var ticket = GetById(id);

            _context.Remove(ticket);
        }
    }
}