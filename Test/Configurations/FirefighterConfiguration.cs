using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Configurations
{
    public class FirefighterConfiguration : IEntityTypeConfiguration<Firefighter>
    {
        public void Configure(EntityTypeBuilder<Firefighter> builder)
        {
            builder.HasKey(f => f.IdFirefighter);

            builder.Property(f => f.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Property(f => f.LastName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasMany(f => f.FirefighterActions)
                .WithOne(fa => fa.Firefighter);

        }
    }
}