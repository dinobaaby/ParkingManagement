

namespace ParkingManagement.Application.DTOs
{
    public class SlotDto
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; } = null!;
        public int AreaId { get; set; }
    }
}
