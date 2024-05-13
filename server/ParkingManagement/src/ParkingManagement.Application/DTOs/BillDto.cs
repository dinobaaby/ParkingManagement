
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.DTOs
{
    public class BillDto
    {
        public int BillId { get; set; }
        public int TicketId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
        public decimal Amount { get; set; }
        
    }
}
