using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Abstractions
{
    public interface IAuthenticationService
    {
        Task<Person> RegisterUserAsync(string login, string password,string email);
        Task<Person> AuthenticateUserAsync(string login, string password);

    }
}
