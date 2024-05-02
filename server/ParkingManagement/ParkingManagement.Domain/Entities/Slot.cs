

namespace ParkingManagement.Domain.Entities
{
    public class Slot
    {
        public int SlotId { get; set; }
        public string SlotName { get; set; } = null!;
        public int SlotType { get; set; }
        public int AreaId { get; set; }
        public virtual Area? Area { get; set; }
    }
}
