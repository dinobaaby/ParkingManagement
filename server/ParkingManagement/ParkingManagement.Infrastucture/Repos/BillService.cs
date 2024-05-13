
using AutoMapper;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Constracts.Helpers;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Infrastucture.Repos
{
    public class BillService : IBillService
    {
        private readonly IServiceRepo<Bill, int> _repo;
        private readonly IMapper _mapper;

        public BillService(IServiceRepo<Bill, int> repo, IMapper mapper )
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<BillDto> CreateBillAsync(BillDto billDto)
        {
            Bill bill = _mapper.Map<Bill>(billDto);
            var result = await _repo.CreateAsync(bill);
            if(result == null)
            {
                return null!;
            }

            return _mapper.Map<BillDto>(result);

        }

        public async Task<bool> DeleteBillAsync(int billId)
        {
            var result = await _repo.GetByIdAsync(billId);
            if(result == null)
            {
                return false;
            }
            var deleteBill = await _repo.DeleteAsync(result);
            if(deleteBill == null)
            {
                return false;
            }
            return false;
        }

        public async Task<BillDto> GetBillByIdAsync(int billId)
        {
            var bill = await _repo.GetByIdAsync(billId);
            if (bill == null)
            {
                return null!;
            }
            return _mapper.Map<BillDto>(bill);
        }


        public async Task<IEnumerable<BillDto>> GetBillsAsync(int pageIndex, int pageSize)
        {
            var bills = await _repo.GetAllAsync();
            if (pageIndex == 0 && pageSize == 0)
            {
                return _mapper.Map<IEnumerable<BillDto>>(bills);
            }
            var result = PaginatedList<Bill>.Create(bills.AsQueryable(), pageIndex, pageSize);

            return _mapper.Map<IEnumerable<BillDto>>(result);

        }

        public async Task<IEnumerable<BillDto>> GetBillsByPlateNumberAsync(string plateNumber)
        {
            var bills = await _repo.GetByNameAsync(s => s.PlateNumber.ToLower().Contains(plateNumber.ToLower()));
            return _mapper.Map<IEnumerable<BillDto>>(bills);    
        }

        public async Task<BillDto> UpdateBillAsync(BillDto billDto)
        {
            var updateBill = _mapper.Map<Bill>(billDto);
            var result = await _repo.UpdateAsync(updateBill);
            if(result == null)
            {
                return null!;
            }

            return _mapper.Map<BillDto>(result);
        }
    }
}
