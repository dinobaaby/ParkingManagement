
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Domain.Entities
{
    public class Cash
    {
        [Key, ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public float CashTendered { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}
