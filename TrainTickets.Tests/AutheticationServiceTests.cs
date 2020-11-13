using System;
using Xunit;
using Moq;
using System.Threading.Tasks;

using SplitMoney.Domain;
using TrainTickets.BusinessLogic.Services;
using TrainTickets.Domain.Exceptions;
using TrainTickets.BusinessLogic;
using TrainTickets.Infrastructure.Abstraction;
using TrainTickets.Domain.Models;

namespace TrainTickets.Tests
{
    public class AutheticationServiceTests
    {
        /*      AutheticateUserAsync        */
        [Fact]
        public async Task AuthenticateUserAsync_LoginDoesNotExist_ReturnNull()
        {
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(x => x.GetByLoginAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<Person>(null));

            var service = new AuthenticationService(repositoryMock.Object);

            var result = await service.AuthenticateUserAsync("login", "password");

            Assert.Null(result);
        }
        [Fact]
        public async Task AuthenticateUserAsync_NotCorrectPassword_ReturnNull()
        {
            //arrange
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(x => x.GetByLoginAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<Person>(null));
            //act
            var service = new AuthenticationService(repositoryMock.Object);

            var result = await service.AuthenticateUserAsync("login1", "fakepassword1");
            //assert
            Assert.Null(result);
        }
        [Theory]
        [InlineData("login1", "password1")]
        [InlineData("login2", "password2")]
        public async Task AuthenticateUserAsync_UserExistsAndPasswordIsCorrect_ReturnUser(string login, string password)
        {
            var logic = new AuthenticationLogic();
            var Salt = logic.GenerateSalt();
            var user = new Person { Login = login, Password = logic.EncryptPassword(password, Salt), salt = Salt};
            
            
            var repositoryMock = new Mock<IPersonRepository>();

            repositoryMock.Setup(x => x.GetByLoginAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(user));
            
            
            var service = new AuthenticationService(repositoryMock.Object);

            var result = await service.AuthenticateUserAsync(login, password);

            Assert.IsType<Person>(result);
        }
        

        /*     registerUserAsync     */
        [Fact]
        public async Task RegisterUserAsync_UserExists_ReturnException()
        {
            //arrange
            var user = new Person { Login = "login", Password = "password" };
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(x => x.GetByLoginAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(user));
            
            //act
            var service = new AuthenticationService(repositoryMock.Object);

            var expectedException = await Record.ExceptionAsync(async
                () => await service.RegisterUserAsync("login", "fakepassword1","fake@mail") );
            //assert    
            
            Assert.IsType<UserAlreadyExistsException>(expectedException);
            //await Assert.ThrowsAsync<UserAlreadyExistsException>(result);
        }

    }
}
