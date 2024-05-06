
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class BillConfiguration : IEntityTypeConfiguration<Bill>
    {
        public void Configure(EntityTypeBuilder<Bill> builder)
        {
            builder.ToTable("BILLS");
            builder.HasKey(b => b.BillId);
            builder.HasOne(b => b.Ticket).WithOne(t => t.Bill).HasForeignKey<Bill>(b => b.TicketId);
        }
    }
}
