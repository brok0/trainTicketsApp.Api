using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.Domain.Models;
using System.Linq;
using TrainTickets.Infrastructure.Abstraction;

namespace TrainTickets.BusinessLogic.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository )
        {


            _personRepository = personRepository;
        }
        public async Task<Person> CreateNewAsync(Person person)
        {
            var newPerson =  _personRepository.Insert(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
            return newPerson;
        }

        public async Task<Person> DeleteAsync(Person person)
        {
            _personRepository.Delete(person);
            await _personRepository.UnitOfWork.SaveChangesAsync();
            return person; 
        }

        public async Task<List<Person>> GetAllAsync()
        {
            var person = await _personRepository.GetAllAsync();
            return person.ToList();
        }


        public async Task<Person> GetPersonAsync(int id)
        {
            var person = await _personRepository.GetByIdAsync(id);
            return person;
        }
        public async Task<string> GetByLoginAsync(string login)
        {
            var person = await _personRepository.GetByLoginAsync(login);
            return person.Password;
        }
    }
}
