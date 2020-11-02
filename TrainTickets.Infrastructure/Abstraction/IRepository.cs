using System;
using Ardalis.Specification;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TrainTickets.Infrastructure.Abstraction
{
    public interface IRepository<T, Tkey>
    {
        IUnitOfWork UnitOfWork{get; }
        Task<T> GetByIdAsync(Tkey id);
        Task<IEnumerable<T>> GetAllAsync();
        T Insert(T item);
        void Update(T item);
        void Delete(T item);
        Task<IEnumerable<T>> GetAsync(ISpecification<T> specification);
        Task<T> GetSingleAsync(ISpecification<T> specification);
    }
}
