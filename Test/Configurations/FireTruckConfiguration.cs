using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Configurations
{
    public class FireTruckConfiguration : IEntityTypeConfiguration<FireTruck>
    {
        public void Configure(EntityTypeBuilder<FireTruck> builder)
        {
            builder.HasKey(ft => ft.IdFireTruck);

            builder.Property(ft => ft.TruckNumber)
                .HasMaxLength(10)
                .IsRequired();

            builder.Property(ft => ft.SpecialEquipment)
                .IsRequired();
        }
    }
}