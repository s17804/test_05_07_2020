using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Configurations
{
    public class FireTruckActionConfiguration : IEntityTypeConfiguration<FireTruckAction>
    {
        public void Configure(EntityTypeBuilder<FireTruckAction> builder)
        {
            builder.HasKey(fta => fta.IdFireTruckAction);

            builder.Property(fta => fta.AssignmentDate)
                .IsRequired();

            builder.HasOne(fta => fta.Action)
                .WithMany(a => a.FireTruckActions)
                .HasForeignKey("IdAction");

            builder.HasOne(fta => fta.FireTruck)
                .WithMany(ft => ft.FireTruckActions)
                .HasForeignKey("IdFireTruck");

        }
    }
}