

namespace ParkingManagement.Domain.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int BillId { get; set; } 
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public Bill Bill { get; set; } = null!;
        public Cash Cash { get; set; } = null!;
        public Credit Credit { get; set; } = null!;
        public BankTransfer BankTransfer { get; set; } = null!;
    }
}
