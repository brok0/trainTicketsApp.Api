using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Exceptions
{
    public class TicketCantBeReservedException : HttpException
    {
        public TicketCantBeReservedException():base(System.Net.HttpStatusCode.Forbidden,"someone has already reserved this ticket")
        {

        }
    }
}
