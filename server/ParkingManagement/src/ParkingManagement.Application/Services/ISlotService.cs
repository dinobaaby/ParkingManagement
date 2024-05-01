
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Application.Services
{
    public interface ISlotService
    {
        Task<IEnumerable<Slot>> GetAllSlotsAsync(int pageIndex, int pageSize);
        Task<IEnumerable<Slot>> GetSlotByNameAsync(string name, int pageIndex, int pageSize);
        Task<Slot> GetSlotByIdAsync(int slotId);
        Task<Slot> CreateSlotAsync(Slot slot);
        Task<bool> DeleteSlotAsync(int slotId);
        Task<bool> UpdateSlotAsync(Slot slot);

        Task<IEnumerable<Slot>> GetSlotByAreaAsync(int areaId, int pageIndex, int pageSize);
    }
}
