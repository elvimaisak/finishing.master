using Flo.FinishingMaster.Infrastructure.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Flo.FinishingMaster.Infrastructure.EntityConfiguration
{
    class RoomConfiguration : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Room");
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
        }
    }
}
