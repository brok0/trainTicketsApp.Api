using Microsoft.Extensions.Localization.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Abstractions
{
    public interface IPersonService
    {
        //Task<Person> Authentificate(string login,string password);
        Task<Person> GetPersonAsync(int id);

        Task<List<Person>> GetAllAsync();

        Task<Person> CreateNewAsync(Person person);

        Task<Person> DeleteAsync(Person person);
        Task<string> GetByLoginAsync(string login);
    }
}
