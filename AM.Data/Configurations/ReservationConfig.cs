using AM.Core.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Data.Configurations
{
    internal class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            //foreign keyy for passenger 

            builder.HasOne(r => r.MyPassenger)

                .WithMany(p => p.Reservations)
                .HasForeignKey(r=> r.PassengerId);
            //foreign keyy for flight 
            builder.HasOne(r => r.MyFlight)

                .WithMany(f => f.Reservations)
                .HasForeignKey(r => r.FlightId);
            //composed key 
            builder.HasKey(r => new
            {
                r.FlightId,
                r.PassengerId
            });


        }

    }
}
