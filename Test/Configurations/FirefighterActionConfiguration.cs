using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Test.Models;

namespace Test.Configurations
{
    public class FirefighterActionConfiguration : IEntityTypeConfiguration<FirefighterAction>
    {
        public void Configure(EntityTypeBuilder<FirefighterAction> builder)
        {
            builder.HasKey(fa => new {fa.IdFirefighter, fa.IdAction});

            builder.HasOne(fa => fa.Firefighter)
                .WithMany(f => f.FirefighterActions)
                .HasForeignKey("IdFirefighter");
            
            builder.HasOne(fa => fa.Action)
                .WithMany(a => a.FirefighterActions)
                .HasForeignKey("IdAction");

        }
    }
}