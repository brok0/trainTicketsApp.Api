using Microsoft.EntityFrameworkCore;
using System;
using TrainTickets.Domain.Models;
using TrainTickets.Infrastructure.Abstraction;

namespace TrainTickets.Infrastructure
{
    public class TrainTicketsContext : DbContext,IUnitOfWork
    {
        
        public TrainTicketsContext(DbContextOptions<TrainTicketsContext> opt ) : base(opt)
        {
            
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Ticket> Tickets { get; set; } 
        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Person>()
                .HasKey(x => x.Id);
            mb.Entity<Person>()
                .Property(x => x.Login)
                .IsRequired()
                .HasMaxLength(50);
            mb.Entity<Person>()
                .Property(x => x.Password)
                .IsRequired();
    
            mb.Entity<Person>()
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(40);


            mb.Entity<Ticket>()
                .HasKey(x => x.Id);

            mb.Entity<Ticket>()
                .Property(x => x.To)
                .HasMaxLength(200)
                .IsRequired();

            mb.Entity<Ticket>()
                .Property(x => x.From)
                .HasMaxLength(200)
                .IsRequired();

            mb.Entity<Ticket>()
                .Property(x => x.ArrivalTime)
                .IsRequired();

            mb.Entity<Ticket>()
                .Property(x => x.DepartureTime)
                .IsRequired();

            mb.Entity<Ticket>()
                .Property(x => x.Price)
                .IsRequired()
                .HasColumnType("money");

            mb.Entity<Ticket>()
                .Property(x => x.TrainNumber);

            mb.Entity<Ticket>()
                .Property(x => x.TrainType)
                .HasMaxLength(35);

            mb.Entity<Ticket>()
                .HasOne(x => x.person)
                .WithMany(x => x.tickets)
                .HasForeignKey(x => x.PersonID);
        }
    }
}
