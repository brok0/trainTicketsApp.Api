using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Abstractions
{
    public interface ITicketService
    {
        Task<Ticket> GetTicketAsync(int id);

        Task<List<Ticket>> GetAllAsync();

        Task<Ticket> CreateNewAsync(Ticket ticket);

        Task<Ticket> DeleteAsync(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
    }
}
