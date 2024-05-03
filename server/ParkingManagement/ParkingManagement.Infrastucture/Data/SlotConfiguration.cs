

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> entity)
        {

            entity.ToTable("SLOT");
            entity.HasKey(s => s.SlotId);
            entity.Property(s => s.SlotName).IsRequired();
            entity.HasOne(s => s.Area).WithMany(a => a.Slots).HasForeignKey(s => s.AreaId).OnDelete(DeleteBehavior.Cascade);
           
        }
    }
}
