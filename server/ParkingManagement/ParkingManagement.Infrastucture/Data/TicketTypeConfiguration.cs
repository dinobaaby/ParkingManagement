
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Data
{
    public class TicketTypeConfiguration : IEntityTypeConfiguration<TicketType>
    {
        public void Configure(EntityTypeBuilder<TicketType> entity)
        {
            entity.ToTable("TICKETTYPE");
            entity.HasKey(t => t.TicketTypeId);
            entity.Property(t => t.TicketTypeName).IsRequired();
            entity.Property(t => t.TicketTypePrice).IsRequired();
        }
    }
}
