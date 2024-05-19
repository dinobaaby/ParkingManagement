

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class CreditConfiguration : IEntityTypeConfiguration<Credit>
    {
        public void Configure(EntityTypeBuilder<Credit> entity)
        {
            entity.ToTable("CREDIT");
            entity.HasKey(c => c.PaymentId);
            entity.Property(c => c.CardNumber).IsRequired();
            entity.Property(c => c.Type).IsRequired();
            entity.Property(c => c.ExpDate).IsRequired();
            entity.HasOne(c => c.Payment).WithOne(p => p.Credit).HasForeignKey<Credit>(c => c.PaymentId);
        }
    }
}
