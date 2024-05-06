
namespace ParkingManagement.Domain.Entities
{
    public class TicketType
    {
        public int TicketTypeId { get; set; }

        public string TicketTypeName { get; set; } = null!;

        public decimal TicketTypePrice { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = null!;
    }
}
