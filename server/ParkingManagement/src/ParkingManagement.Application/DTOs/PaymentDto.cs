

using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.DTOs
{
    public class PaymentDto
    {
        public int PaymentId { get; set; }
        public int BillId { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
       
    }
}
