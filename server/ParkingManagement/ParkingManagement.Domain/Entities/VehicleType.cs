

namespace ParkingManagement.Domain.Entities
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string VehicleTypeName { get; set; } = null!;
        public virtual ICollection<Vehicle>? Vehicles {  get; set; }
    }
}
