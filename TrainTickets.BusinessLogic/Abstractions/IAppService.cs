using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Abstractions
{
    public interface IAppService
    {
        Task<Ticket> GetTicketAsync(int id);

        Task<List<Ticket>> GetAllAsync();

        Task<Ticket> CreateNewAsync(Ticket ticket);

        Task<Ticket> DeleteAsync(Ticket ticket);
        Task<Ticket> UpdateTicket(Ticket ticket);
        Task<List<Ticket>> GetTicketBySearchRequestAsync(string To,string From);

        Task<List<Ticket>> GetTicketsForUser(int userId);
        Task UserAddsTicket(int ticketId,int userId);
        Task ChangePersonLogin(string personName, string newLogin);
        Task ChangePersonPassword(string personName, string newPassword);
        Task ChangePersonEmail(string personName, string newEmail);

        Task<HashSet<string>> GetAllCities();


    }
}
