
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class VehicleTypeConfuiguration : IEntityTypeConfiguration<VehicleType> 
    {
        public void Configure(EntityTypeBuilder<VehicleType> entity)
        {      
            entity.ToTable("VEHICLETYPE");
            entity.HasKey(c => c.VehicleTypeId);
            entity.Property(v => v.VehicleTypeName).IsRequired();
        }
    }
}
