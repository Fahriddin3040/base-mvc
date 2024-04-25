using System.Data;
using SQLitePCL;
using TicketOrdering.Data;
using TicketOrdering.Models;

namespace TicketOrdering.Repositories
{
    public class ClientRepository
    {
        private readonly ApplicationDbContext _context; 

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Client> GetAll()
        {
            return _context.Clients;
        }

        public Client GetById(int id)
        {
            return _context.Clients.SingleOrDefault(cl => cl.Id == id)!;
        }

        public void Create(Client client)
        {
            _context.Clients.Add(client);
            _context.SaveChanges();
        }

        public void Update(int id)
        {
            var client = GetById(id);
            _context.Clients.Update(client);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var client = GetById(id);

            _context.Remove(client);
            _context.SaveChanges();
        }
    }
}