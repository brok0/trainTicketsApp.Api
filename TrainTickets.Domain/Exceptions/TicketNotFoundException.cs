using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Exceptions
{
    public class TicketNotFoundException : HttpException 
    {
        public TicketNotFoundException() : base(System.Net.HttpStatusCode.BadRequest, "Ticket Not Found")
        {
            

        }
    }
}
