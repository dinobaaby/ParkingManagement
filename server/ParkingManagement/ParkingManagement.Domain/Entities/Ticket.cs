

namespace ParkingManagement.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TicketStatus { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int SlotId { get; set; }
        public int TicketTypeId { get; set; }
        public TicketType TicketType { get; set; } = null!;
        public Slot Slot { get; set; } = null!;
    }
}
