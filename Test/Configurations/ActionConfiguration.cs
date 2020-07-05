using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Configurations
{
    public class ActionConfiguration : IEntityTypeConfiguration<Action>
    {
        public void Configure(EntityTypeBuilder<Action> builder)
        {
            builder.HasKey(a => a.IdAction);

            builder.Property(a => a.StartTime)
                .IsRequired();

            builder.Property(a => a.EndTime);

            builder.Property(a => a.NeedSpecialEquipment)
                .IsRequired();

            builder.HasMany(a => a.FirefighterActions)
                .WithOne(fa => fa.Action);

            builder.HasMany(a => a.FireTruckActions)
                .WithOne(fta => fta.Action);
        }
    }
}