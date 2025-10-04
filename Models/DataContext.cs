using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public partial class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions) // Hace referencia al constructor de la clase base DbContext (padre)
        {
            
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<FlightConnection> FlightConnections { get; set; }

        /// <summary>
        /// Overrided method to configure the model
        /// </summary>
        /// <param name="modelBuilder">Define the shape of the entites and the relation between them</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring the primary keys
            modelBuilder.Entity<Flight>()
                .HasKey(f => f.FlightNumber); // Composite primary key

            modelBuilder.Entity<Connection>()
                .HasKey(c => c.ConnectionId); // Composite primary key

            modelBuilder.Entity<FlightConnection>()
                .HasKey(fc => new {fc.FlightNumber, fc.ConnectionId}); // Composite primary key

            // Configuring the relationships
            modelBuilder.Entity<FlightConnection>()
                .HasOne(fc => fc.Flight)
                .WithMany(f => f.FlightConnections)
                .HasForeignKey(fc => fc.FlightNumber);

            modelBuilder.Entity<FlightConnection>()
                .HasOne(fc => fc.Connection)
                .WithMany(c => c.FlightConnections)
                .HasForeignKey(fc => fc.ConnectionId);

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<User>()
                .Property(u => u.UserName).IsRequired();
        }
    }
}
