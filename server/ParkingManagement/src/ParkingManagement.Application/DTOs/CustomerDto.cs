

namespace ParkingManagement.Application.DTOs
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string CustomerIdCard { get; set; } = null!;
    }
}
