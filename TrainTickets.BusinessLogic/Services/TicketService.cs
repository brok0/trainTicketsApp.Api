using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.Domain.Models;
using TrainTickets.Infrastructure.Abstraction;
using TrainTickets.Infrastructure.Repositories;

namespace TrainTickets.BusinessLogic.Services
{
    public class TicketService : ITicketService
    {
        private readonly ITicketsRepository _ticketRepository;
        public TicketService(ITicketsRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<Ticket> CreateNewAsync(Ticket ticket)
        {
            var newTicket = _ticketRepository.Insert(ticket);
            await _ticketRepository.UnitOfWork.SaveChangesAsync();
            return newTicket;
        }

        public async Task<Ticket> DeleteAsync(Ticket ticket)
        {
            _ticketRepository.Delete(ticket);
            await _ticketRepository.UnitOfWork.SaveChangesAsync();
            return ticket;
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            var ticket = await _ticketRepository.GetAllAsync();
            return ticket.ToList();
        }

        public async Task<Ticket> GetTicketAsync(int id)
        {
            var ticket = await _ticketRepository.GetByIdAsync(id);
            return ticket;
        }
        
        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
              _ticketRepository.Update(ticket);
            await _ticketRepository.UnitOfWork.SaveChangesAsync();
            return ticket;
        }

    }
}
