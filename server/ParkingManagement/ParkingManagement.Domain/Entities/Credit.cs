
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Domain.Entities
{
    public class Credit
    {
        [Key, ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public string CardNumber { get; set; } = null!;
        public string Type { get; set; } = null!;
        public DateTime ExpDate { get; set; }
        public Payment Payment { get; set; } = null!;
    }
}
