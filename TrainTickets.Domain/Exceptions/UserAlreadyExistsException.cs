using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Exceptions
{
    public class UserAlreadyExistsException :HttpException
    {
        public UserAlreadyExistsException() : base(System.Net.HttpStatusCode.BadRequest,"User with this login name already exists")
        {

        }
    }
}
