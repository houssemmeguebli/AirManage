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
    internal class PlaneConfig : IEntityTypeConfiguration<Plane>
    {
        public void Configure(EntityTypeBuilder<Plane> builder)
        {
            //change table name
            builder.ToTable("MyPlanes");
            //change column name
            builder.Property(p => p.Capacity).HasColumnName("PlaneCapacity");
            //primary key
            builder.HasKey(p => p.PlaneId);


        }
    }
}
