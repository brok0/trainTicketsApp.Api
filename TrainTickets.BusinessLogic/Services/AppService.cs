using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.BusinessLogic.Specifications;
using TrainTickets.Domain.Models;
using TrainTickets.Domain.Exceptions;
using TrainTickets.Infrastructure.Abstraction;
using TrainTickets.Infrastructure.Repositories;

namespace TrainTickets.BusinessLogic.Services
{
    public class AppService : IAppService
    {
        private readonly ITicketsRepository _ticketRepository;
        private readonly IPersonRepository _personRepository;

        public AppService(ITicketsRepository ticketRepository,IPersonRepository personRepository)
        {
            _ticketRepository = ticketRepository;
            _personRepository = personRepository;
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

        public async Task<List<Ticket>> GetTicketBySearchRequestAsync(string To,string From)
        {
            SearchTicketsSpecification search = new SearchTicketsSpecification(To,From);
            var searchedTicket = await _ticketRepository.GetAsync(search);
            
            if (searchedTicket == null )
             throw new TicketNotFoundException();
            
            return searchedTicket.ToList();
        }

        public async Task<Ticket> UpdateTicket(Ticket ticket)
        {
              _ticketRepository.Update(ticket);
            await _ticketRepository.UnitOfWork.SaveChangesAsync();
            return ticket;
        }

        public async Task<List<Ticket>> GetTicketsForUser(int userId)
        {
            UserTicketsSpecification userTickets = new UserTicketsSpecification(userId);
            var tickets = await _ticketRepository.GetAsync(userTickets);
            if (tickets == null)
                throw new TicketNotFoundException();
            return tickets.ToList();
        }
        public async Task UserAddsTicket(int ticketId,int userId)
        {
            var ticket = await _ticketRepository.GetByIdAsync(ticketId);
            if (ticket == null) throw new TicketNotFoundException();
            if (ticket.PersonID != 0) throw new TicketCantBeReservedException();  // if field has default value(0) than user can have this ticket
            ticket.PersonID = userId;
            await _ticketRepository.UnitOfWork.SaveChangesAsync();

        }
        public async Task ChangePersonLogin(string userName,string newLogin)
        {
            if (userName == newLogin)
                throw new UserAlreadyExistsException();
            var currentUser = await _personRepository.GetByLoginAsync(userName);

            currentUser.Login = newLogin;

            await _personRepository.UnitOfWork.SaveChangesAsync();

            
        }
        public async Task ChangePersonPassword(string userName, string password)
        {
            
            var currentUser = await _personRepository.GetByLoginAsync(userName);

            AuthenticationLogic logic = new AuthenticationLogic();

            var salt = logic.GenerateSalt();
            var encryptedPassword = logic.EncryptPassword(password, salt);

            currentUser.Password = encryptedPassword;
            currentUser.salt = salt;

            await _personRepository.UnitOfWork.SaveChangesAsync();

            
        }
        public async Task ChangePersonEmail(string userName, string newEmail)
        {
            
            var currentUser = await _personRepository.GetByLoginAsync(userName);

            currentUser.Email = newEmail;

            await _personRepository.UnitOfWork.SaveChangesAsync();

           
        }
        public async Task<HashSet<string>> GetAllCities()
        {
            var tickets = await _ticketRepository.GetAllAsync();
            var temp = tickets.ToList();
            var result = temp.Select(x =>x.To).ToList();
            result.AddRange(temp.Select(x => x.From));
            HashSet<string> hashresult = new HashSet<string>(result);
     
            return hashresult;
        }
    }
}
