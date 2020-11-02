
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Exceptions
{
    public class UserNotFoundException : HttpException
    {
        public UserNotFoundException() : base(System.Net.HttpStatusCode.NotFound, "user not found")
        {

        }
    }
}
