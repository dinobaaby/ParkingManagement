

using ParkingManagement.Application.DTOs;

namespace ParkingManagement.Application.Services
{
    public interface IBillService
    {
        Task<IEnumerable<BillDto>> GetBillsAsync(int pageIndex, int pageSize);
        Task<BillDto> GetBillByIdAsync(int billId);
        Task<BillDto> CreateBillAsync(BillDto billDto);
        Task<BillDto> UpdateBillAsync(BillDto billDto);
        Task<bool> DeleteBillAsync(int billId);
        Task<IEnumerable<BillDto>> GetBillsByPlateNumberAsync(string plateNumber);
    }
}
