

namespace ParkingManagement.Domain.Entities
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleColor { get; set; } = null!;
        public string VehiclePlateNumber { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; }
        public virtual VehicleType? VehicleTypes { get; set; }
    }
}
