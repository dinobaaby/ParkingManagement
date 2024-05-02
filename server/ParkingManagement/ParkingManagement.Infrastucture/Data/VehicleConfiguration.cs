
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
           
            entity.ToTable("VEHICLE");
            entity.HasKey(c => c.VehicleId);
            entity.Property(c => c.VehiclePlateNumber).IsRequired();
            entity.HasOne(c => c.VehicleTypes).WithMany(c => c.Vehicles).HasForeignKey(c => c.VehicleTypeId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(c => c.Customer).WithMany(c => c.Vehicles).HasForeignKey(c => c.CustomerId).OnDelete(DeleteBehavior.Restrict);

           
        }
    }
}
