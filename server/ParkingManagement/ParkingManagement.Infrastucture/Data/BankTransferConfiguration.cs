using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ParkingManagement.Domain.Entities;


namespace ParkingManagement.Infrastucture.Data
{
    public class BankTransferConfiguration : IEntityTypeConfiguration<BankTransfer>
    {
        public void Configure(EntityTypeBuilder<BankTransfer> entity)
        {
            entity.ToTable("BANKRANSFER");
            entity.HasKey(c => c.PaymentId);
            entity.Property(c => c.BankName).IsRequired();
            entity.Property(c => c.BankId).IsRequired();
            entity.HasOne(c => c.Payment).WithOne(p => p.BankTransfer).HasForeignKey<BankTransfer>(c => c.PaymentId);
        }
    }
}
