
namespace ParkingManagement.Application.DTOs
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int TicketStatus { get; set; }
        public DateTime? IssueDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string VehicleImage { get; set; } = null!;
        public int SlotId { get; set; }
        public int TicketTypeId { get; set; }
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; } = null!;
    }
}
