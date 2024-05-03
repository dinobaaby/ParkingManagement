

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class CutomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("CUSTOMER");
            entity.HasKey(c => c.CustomerId);
            entity.Property(c => c.CustomerName).IsRequired();
            entity.Property(c => c.CustomerPhoneNumber).IsRequired().HasMaxLength(13);
            entity.Property(c => c.CustomerIdCard).IsRequired().HasMaxLength(20);
            
        }
    }
}
