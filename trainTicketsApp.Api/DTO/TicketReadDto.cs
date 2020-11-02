using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainTicketsApp.Api.DTO
{
    public class TicketReadDto
    {
       
        public int Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public decimal Price { get; set; }
        public string TrainNumber { get; set; }

        public string TrainType { get; set; }

        public int PersonID { get; set; }
    }
}
