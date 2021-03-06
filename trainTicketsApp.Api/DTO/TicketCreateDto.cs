﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trainTicketsApp.Api.DTO
{
    public class TicketCreateDto
    {
        

        public string To { get; set; }
        public string From { get; set; }

        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int Price { get; set; }
        public string TrainNumber { get; set; }

        public string TrainType { get; set; }

        

        public int PersonID { get; set; }
    }
}
