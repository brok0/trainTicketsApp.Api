
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.Domain.Models;

namespace TrainTickets.Infrastructure.Abstraction
{
    public interface IPersonRepository : IRepository<Person,int>
    {
        Task<Person> GetByLoginAsync(string login);
    }
}
