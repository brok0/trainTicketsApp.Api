using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Specifications
{
    class UserTicketsSpecification:Specification<Ticket>
    {
        public UserTicketsSpecification(int userId)

        {
            Query.Where(x => x.PersonID == userId);
                
        }
    }
}
