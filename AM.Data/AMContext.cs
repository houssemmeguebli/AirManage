using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.Core.Domain;
using AM.Data.Configurations;
using Microsoft.EntityFrameworkCore;


namespace AM.Data
{
    public class AMContext:DbContext
    {
        public DbSet<Passenger>  Passengers { get; set; }
        public DbSet<Flight>  Flights { get; set; }
        public DbSet<Plane>  Planes { get; set; }
        public DbSet<Staff>  Staffs { get; set; }
        public DbSet<Traveller>  Travellers { get; set; }
       // public DbSet<Reservation> Resrvations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=(localdb)\mssqllocaldb;
                Initial Catalog = Airport;
                Integrated Security = true");
            //to get objects by navigation
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {   
            modelBuilder.ApplyConfiguration(new FlightConfig());
            modelBuilder.ApplyConfiguration(new PlaneConfig());
            modelBuilder.ApplyConfiguration(new PassengerConfig());
            //QUESTION BONUS: Mapper toute les proprietes de type string en des colones
            //de type nvarcha(50) sans ustiliser les preconventions
            /*
            foreach (var type in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var prop in type.GetProperties().Where(p => p.GetType() == typeof(string)))
                {
                    prop.SetMaxLength(50);
                    //ou bien
                    //prop.SetColumnType("nvarchar(50)");
                };
            }
            */
            modelBuilder.ApplyConfiguration(new ReservationConfig());

        }
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>()
                .HaveColumnType("date");
        }
    }
}
