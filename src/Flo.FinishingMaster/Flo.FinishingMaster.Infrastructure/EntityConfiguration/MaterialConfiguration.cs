using Flo.FinishingMaster.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Flo.FinishingMaster.Infrastructure.EntityConfiguration
{
    class MaterialConfiguration : IEntityTypeConfiguration<Material>
    {
        public void Configure(EntityTypeBuilder<Material> builder)
        {
            builder.ToTable("Material");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.MaterialType).HasConversion(new EnumToStringConverter<EMaterialType>());

        }
    }
}
