
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class CashConfiguration : IEntityTypeConfiguration<Cash>
    {
        public void Configure(EntityTypeBuilder<Cash> entity)
        {
            entity.ToTable("CASH");
            entity.HasKey(c => c.PaymentId);
            entity.Property(c => c.CashTendered).IsRequired();
            entity.HasOne(c => c.Payment).WithOne(p => p.Cash).HasForeignKey<Cash>(c => c.PaymentId);
        }
    }
}
