using Microsoft.EntityFrameworkCore;
using SplitMoney.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;
using TrainTickets.Infrastructure.Abstraction;

namespace TrainTickets.Infrastructure.Repositories
{
  
    public class TicketRepository : BaseRepository<Ticket, int>, ITicketsRepository
    {
        public override IUnitOfWork UnitOfWork => (TrainTicketsContext)_context;

        public TicketRepository(TrainTicketsContext context) : base(context)
        {

        }
        
    }
}
