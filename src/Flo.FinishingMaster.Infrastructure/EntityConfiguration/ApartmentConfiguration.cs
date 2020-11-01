using Flo.FinishingMaster.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flo.FinishingMaster.Infrastructure.EntityConfiguration
{
    class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartment");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
