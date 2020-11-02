using Ardalis.Specification;
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
    public class PersonRepository : BaseRepository<Person, int>, IPersonRepository
    {
        public override IUnitOfWork UnitOfWork => (TrainTicketsContext)_context;

        public PersonRepository(TrainTicketsContext context) : base(context)
        {

        }
        public async Task<Person> GetByLoginAsync(string login)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Login.Equals(login));
        }
    }
}
