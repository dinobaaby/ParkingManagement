
namespace ParkingManagement.Application.DTOs
{
    public class VehicleDto
    {
        public int VehicleId { get; set; }
        public string VehicleColor { get; set; } = null!;
        public string VehiclePlateNumber { get; set; } = null!;
        public string VehicleImage { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public int CustomerId { get; set; }
    }
}
