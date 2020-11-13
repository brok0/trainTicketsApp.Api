using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Abstractions;
using TrainTickets.Domain.Models;
using TrainTickets.Infrastructure.Abstraction;
using TrainTickets.Domain.Exceptions;

namespace TrainTickets.BusinessLogic.Services
{
    
        public class AuthenticationService : IAuthenticationService
        {
            private readonly IPersonRepository _personRepository;
            AuthenticationLogic logic = new AuthenticationLogic();
            public AuthenticationService(IPersonRepository personRepository)
            {
                _personRepository = personRepository;
            }

            public async Task<Person> AuthenticateUserAsync(string login, string password)
            {
                var user = await _personRepository.GetByLoginAsync(login);

                if (user == null)
                {
                    return null;
                }

                if (logic.ComparePasswords(password, user))
                {
                    return user;
                }

                return null;
            }

            public async Task<Person> RegisterUserAsync(string login, string password,string email)
            {
                if ((await _personRepository.GetByLoginAsync(login)) != null)
                {
                    throw new UserAlreadyExistsException();
                }

                byte[] salt = logic.GenerateSalt();



            var encryptedPassword = logic.EncryptPassword(password, salt);

            var person = new Person
            {
                Login = login,
                Password = encryptedPassword,
                Email = email, 
                salt = salt,
            };

                person = _personRepository.Insert(person);

                await _personRepository.UnitOfWork.SaveChangesAsync();

                return person;
            }

            


        }
    
}
    
