

namespace ParkingManagement.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int TicketId { get; set; }
        public decimal Amount { get; set; }
        public Ticket Ticket { get; set; } = null!;
    }
}
