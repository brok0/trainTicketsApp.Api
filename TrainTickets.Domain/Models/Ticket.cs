using SplitMoney.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Models
{
    public class Ticket : IEntity<int>
    {
        public int Id { get; set; }

        public string To { get; set; }
        public string From { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }
        public string TrainNumber { get; set; }

        public string TrainType {get;set; }

        public Person person { get; set; }

        public int PersonID { get; set; }

    }
}
