

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable("TICKETS");
            builder.HasKey(t => t.TicketId);
            
            builder.HasOne(t => t.TicketType).WithMany(tt => tt.Tickets).HasForeignKey(t => t.TicketTypeId);
            builder.HasOne(t => t.Slot).WithOne(s => s.Ticket).HasForeignKey<Ticket>(t => t.SlotId);

           
        }
    }
}
