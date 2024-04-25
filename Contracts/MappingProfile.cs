using AutoMapper;
using TicketOrdering.Models;

namespace TicketOrdering.Contracts
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingRules();
        }

        public void ApplyMappingRules()
        {
            CreateMap<Client, ClientCreateDTO>().ReverseMap();
            CreateMap<ClientCreateDTO, Client>().ReverseMap();
            CreateMap<Ticket, TicketCreateDTO>().ReverseMap();
        }
    }
}