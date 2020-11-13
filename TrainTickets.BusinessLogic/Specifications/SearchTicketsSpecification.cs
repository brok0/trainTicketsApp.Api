using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Text;
using TrainTickets.Domain.Models;

namespace TrainTickets.BusinessLogic.Specifications
{
    class SearchTicketsSpecification:Specification<Ticket>
    {
        public SearchTicketsSpecification(string To,string From)
        {
            Query.Where((tt => (tt.From == From && tt.To == To)));   // && tt.departureDate == searchTicket.departureDate - add this condition later
                
                
        }
    }
}
