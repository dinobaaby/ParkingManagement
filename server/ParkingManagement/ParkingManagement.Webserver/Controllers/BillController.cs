using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{

    [ApiController]
    [Route("api/bills")]
    public class BillController : Controller
    {
        private readonly IBillService _billService;
        public BillController(IBillService billService)
        {
            _billService = billService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBill(int pageIndex, int pageSize)
        {
            try
            {
                var response = await _billService.GetBillsAsync(pageIndex, pageSize);
                return Ok(new ServerResponse(response, true, "Bills retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }

        }

        [HttpPost]
        public async Task<IActionResult> CreateBill(BillDto dto)
        {
            try
            {
                var response = await _billService.CreateBillAsync(dto);
                if(response == null)
                {
                    return BadRequest(new ServerResponse(null, false, "Failed to create bill"));
                }

                return Ok(new ServerResponse(response, true, "Bills retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("{billId}")]
        public async Task<IActionResult> GetBillById(int billId)
        {
            try
            {
                var response = await _billService.GetBillByIdAsync(billId);
                if (response == null)
                {
                    return BadRequest(new ServerResponse(null, false, "Failed to retrieve bill"));
                }
                return Ok(new ServerResponse(response, true, "Bill retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBill(BillDto dto)
        {
            try
            {
                var response = await _billService.UpdateBillAsync(dto);
                if (response == null)
                {
                    return BadRequest(new ServerResponse(null, false, "Failed to update bill"));
                }
                return Ok(new ServerResponse(response, true, "Bill updated successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpDelete("{billId}")]
        public async Task<IActionResult> Delete(int billId)
        {
            try
            {
                bool deleteSuccess = await _billService.DeleteBillAsync(billId);
                if (!deleteSuccess)
                {
                    return BadRequest(new ServerResponse(null, false, "Failed to delete bill"));
                }
                return Ok(new ServerResponse(null, true, "Bill deleted successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("PlateNumber/{plateNumber}")]
        public async Task<IActionResult> GetBillByPlateNumber(string plateNumber)
        {
            try
            {
                var response = await _billService.GetBillsByPlateNumberAsync(plateNumber);
                return Ok(new ServerResponse(response, true, "Bills retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }   

    }
}
