using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketOrdering.Contracts;
using TicketOrdering.Models;
using TicketOrdering.Services;

namespace TicketOrdering.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : Controller
    {
        private readonly ClientService _service;

        private readonly IMapper _mapper;

        public ClientController(ClientService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Client>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Client> GetById([FromQuery] int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult<Client> Create([FromBody] ClientCreateDTO clientCreateDTO)
        {
            var newClient = _mapper.Map<Client>(clientCreateDTO);

            _service.Create(newClient);

            return Ok(_service.GetAll().Last());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }


    }
}