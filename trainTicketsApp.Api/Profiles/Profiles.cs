using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TrainTickets.Domain.Models;
using trainTicketsApp.Api.DTO;

namespace trainTicketsApp.Api.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketCreateDto, Ticket>();

            CreateMap<Person,PersonReadDto>();
            CreateMap<PersonCreateDto, Person>();

            CreateMap<TicketUpdateDto,Ticket>();
        }
        
    }
}
