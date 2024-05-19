
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> entity)
        {
            entity.ToTable("PAYMENT");
            entity.HasKey(p => p.PaymentId);
            entity.Property(p => p.Amount).IsRequired();
            entity.Property(p => p.CreatedAt).HasDefaultValueSql("GETDATE()");
            entity.HasOne(p => p.Bill).WithOne(b => b.Payment).HasForeignKey<Payment>(p => p.BillId);

        }
    }
}
