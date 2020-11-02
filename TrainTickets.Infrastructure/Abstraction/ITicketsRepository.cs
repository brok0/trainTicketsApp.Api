using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.Infrastructure.Abstraction
{
    public interface ITicketsRepository : IRepository<Ticket,int>
    {
        
    }
}
