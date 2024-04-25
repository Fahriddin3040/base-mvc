using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TicketOrdering.Contracts;
using TicketOrdering.Models;
using TicketOrdering.Services;

namespace TicketOrdering.Controllers
{
    [ApiController]
    [Route("tickets")]
    public class TicketController : Controller
    {
        private readonly TicketService _service;

        private readonly IMapper _mapper;

        public TicketController(TicketService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<Ticket>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Ticket> GetById([FromQuery] int id)
        {
            return Ok(_service.GetById(id));
        }

        [HttpPost]
        public ActionResult<Ticket> Create([FromBody] TicketCreateDTO TicketCreateDTO)
        {
            var newTicket = _mapper.Map<Ticket>(TicketCreateDTO);

            _service.Create(newTicket);

            return Ok(_service.GetAll().LastOrDefault());
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _service.Delete(id);
            return NoContent();
        }


    }
}