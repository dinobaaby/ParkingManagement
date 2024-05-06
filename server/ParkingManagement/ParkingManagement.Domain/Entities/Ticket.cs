

using System.Diagnostics.CodeAnalysis;

namespace ParkingManagement.Domain.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int TicketStatus { get; set; }
        public DateTime? IssueDate { get; set; }
        [AllowNull]
        public DateTime? ExpiryDate { get; set; }
        public int SlotId { get; set; }
        public int TicketTypeId { get; set; }

        [AllowNull]
        public int? VehicleId { get; set; }
        [AllowNull]
        public string? PlateNumber { get; set; } 
        [AllowNull]
        public string? VehicleImage { get; set; } 
        public TicketType? TicketType { get; set; }
        public Slot? Slot { get; set; } = null!;
        public Vehicle? Vehicle { get; set; } 

        public Bill? Bill { get; set; } 

    }
}
