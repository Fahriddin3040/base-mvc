using TicketOrdering.Models;
using TicketOrdering.Repositories;

namespace TicketOrdering.Services
{
    public class ClientService
    {

        private readonly ClientRepository _repository;

        public ClientService(ClientRepository ClientRepository)
        {
            _repository = ClientRepository;
        }

        public IList<Client> GetAll()
        {
            return _repository.GetAll().ToArray();
        }

        public Client GetById(int id)
        {
            return _repository.GetById(id);
        }

        public void Create(Client client)
        {
            _repository.Create(client);
        }

        public void Update()
        {}

        public void Delete(int id)
        {
            _repository.Delete(id);
        }
    }
}