using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainTickets.BusinessLogic.Services;
using TrainTickets.Domain.Exceptions;
using TrainTickets.Domain.Models;
using TrainTickets.Infrastructure.Abstraction;
using Xunit;

namespace TrainTickets.Tests
{
    public class AppServiceTests
    {
        [Fact]
        public async Task GetTicketBySearchRequest_NothingFound_ThrowException()
        {
            //arrange
  
            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetAsync(It.IsAny<Specification<Ticket>>())).Returns(Task.FromResult <IEnumerable<Ticket>>(null));

            //act
            var service = new AppService(repositoryMock.Object, null);

            var actualResult = service.GetTicketBySearchRequestAsync("notExistentPlace", "notExistentPlace");

            //assert
            await Assert.ThrowsAsync<TicketNotFoundException>(async () => await actualResult);
        }
        [Fact]
        public async Task GetTicketBySearchRequest_InputedNothing_ThrowException()
        {
            //arrange
            
            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetAsync(It.IsAny<Specification<Ticket>>())).Returns(Task.FromResult<IEnumerable<Ticket>>(null));

            //act
            var service = new AppService(repositoryMock.Object, null);

            var actualResult = service.GetTicketBySearchRequestAsync("notExistentPlace", "notExistentPlace");

            //assert
            await Assert.ThrowsAsync<TicketNotFoundException>(async () => await actualResult);
        }
        [Fact]
        public async Task GetTicketBySearchRequest_TicketFound_ReturnNotNull()
        {
            //arrange
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime() };

            List<Ticket> ticketsList = new List<Ticket>();
            ticketsList.Add(ticket);


            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetAsync(It.IsAny<Specification<Ticket>>())).Returns(Task.FromResult((IEnumerable<Ticket>)ticketsList));


            //act
            var service = new AppService(repositoryMock.Object, null);

            var actualResult = await service.GetTicketBySearchRequestAsync(ticket.To, ticket.From);

            //assert
            Assert.NotNull(actualResult);
        }
        [Fact]


        public async Task CreateNewTicket_ReturnTicket()
        {
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime() };

            var repositoryMock = new Mock<ITicketsRepository>();
            repositoryMock.Setup(x => x.Insert(It.IsAny<Ticket>())).Returns(await Task.FromResult(ticket));
            repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(repositoryMock.Object, null);

            Assert.NotNull(service.CreateNewAsync(ticket));



        }
        [Fact]
        public void DeleteTicket_ReturnDeletedTicket()
        {
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime() };

            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.Delete(It.IsAny<Ticket>()));
            repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(repositoryMock.Object, null);

            Assert.NotNull(service.DeleteAsync(ticket));



        }
       [Fact]
       public async Task GetTicketsForUser_ThrowsException()
        {
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime(), person = new Person { Id = 0 } ,PersonID = 0};

            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetAsync(It.IsAny<Specification<Ticket>>())).Returns(Task.FromResult<IEnumerable<Ticket>>(null));

            var service = new AppService(repositoryMock.Object, null);
            await Assert.ThrowsAsync<TicketNotFoundException>(async () => await service.GetTicketsForUser(1));
        }   
        [Fact]
        public async Task ChangePersonEmail_ReturnChangedUser()
        {
            var user = new Person { Id = 1, Email = "oldmail",Login="login" };
            var repositoryMock = new Mock<IPersonRepository>();
            repositoryMock.Setup(x => x.GetByLoginAsync(It.IsAny<string>())).Returns(Task.FromResult(user));
            repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));

            var service = new AppService(null, repositoryMock.Object);
            var oldMail = user.Email;
            await service.ChangePersonEmail(user.Login, "New mail");


            Assert.NotNull(user);
            Assert.NotEqual(user.Email,oldMail);

        }
         [Fact]

         public async Task UserAddsTickets_SuccessfullBehaviour()
         {
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime(), person = new Person { Id = 0 }, PersonID = 0 };
            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(ticket));
            repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));
            var service = new AppService(repositoryMock.Object, null);

            await service.UserAddsTicket(0, 1);

            Assert.NotEqual(0, ticket.PersonID);
        }
        [Fact]

        public async Task UserAddsTickets_UnSuccessfullBehaviour()
        {
            var ticket = new Ticket { Id = 0, To = "to", From = "from", ArrivalTime = new DateTime(), DepartureTime = new DateTime(), person = new Person { Id = 1 }, PersonID = 1 };
            var repositoryMock = new Mock<ITicketsRepository>();

            repositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<int>())).Returns(Task.FromResult(ticket));
            repositoryMock.Setup(x => x.UnitOfWork.SaveChangesAsync(default));
            var service = new AppService(repositoryMock.Object, null);


            await Assert.ThrowsAsync<TicketCantBeReservedException>(async () => await service.UserAddsTicket(0, 1));
        }
    }
}


