

using ParkingManagement.Domain.Entities.Authetication;

namespace ParkingManagement.Domain.Entities
{
    public class Area
    {
        public int AreaId { get; set; }
        public string AreaName { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public virtual ApplicationUser? User { get; set; }

        public virtual ICollection<Slot>? Slots { get; set; }
    }
}
