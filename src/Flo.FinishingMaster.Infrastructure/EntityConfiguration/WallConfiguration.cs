using Flo.FinishingMaster.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flo.FinishingMaster.Infrastructure.EntityConfiguration
{
    class WallConfiguration : IEntityTypeConfiguration<Wall>
    {
        public void Configure(EntityTypeBuilder<Wall> builder)
        {
            builder.ToTable("Wall");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
