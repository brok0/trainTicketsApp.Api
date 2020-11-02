using SplitMoney.Domain.Abstraction;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrainTickets.Domain.Models
{
    public class Person : IEntity<int>
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public byte[] salt { get; set; }
        public ICollection<Ticket> tickets { get; set; }
    }
}
