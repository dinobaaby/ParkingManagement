

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> entity)
        {
        
            entity.ToTable("AREA");
            entity.HasKey(a => a.AreaId);
            entity.Property(a => a.AreaName).IsRequired();
            entity.HasOne(e => e.User).WithMany(u => u.Areas).HasForeignKey(a => a.UserId);
          
        }
    }
}
