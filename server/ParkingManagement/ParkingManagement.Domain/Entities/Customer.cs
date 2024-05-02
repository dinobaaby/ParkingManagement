

namespace ParkingManagement.Domain.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public string CustomerPhoneNumber { get; set; } = null!;
        public string CustomerIdCard { get; set; } = null!;

        public virtual ICollection<Vehicle>? Vehicles { get; set; }
    }
}
