
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingManagement.Domain.Entities
{
    public class BankTransfer
    {
        [Key, ForeignKey("Payment")]
        public int PaymentId { get; set; }
        public string BankName { get; set; } = null!;
        public string BankId { get; set; } = null!; 
        public Payment Payment { get; set; } = null!;
    }
}
