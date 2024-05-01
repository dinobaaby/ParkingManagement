using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/slot")]
    public class SlotController : Controller
    {
        private readonly ISlotService _slotService;

        public SlotController(ISlotService slotService)
        {
            _slotService = slotService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSlot(int pageIndex, int pageSize)
        {


            try
            {
                var result = await _slotService.GetAllSlotsAsync(pageIndex, pageSize);
                

                return Ok(new ServerResponse(result, false, "Get slot success"));
            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(Slot slot)
        {
            try
            {
                var result = await _slotService.CreateSlotAsync(slot);
                if(result is null)
                {
                    return BadRequest(new ServerResponse(result, Message: "Create slot is faild"));
                }
                return Ok(new ServerResponse(result, Message: "Create slot success"));
            }catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }



        [HttpGet("GetSlotByArea/{areaId}")]
        public async Task<IActionResult> GetSlotByArea(int areaId, int pageIndex, int pageSize)
        {

            try
            {
                var result = await _slotService.GetSlotByAreaAsync(areaId, pageIndex, pageSize);
                return Ok(new ServerResponse(result, Message: "Get slot by area successfull"));

            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlotById(int id)
        {
            try
            {
                var result = await _slotService.GetSlotByIdAsync(id);
                return Ok(new ServerResponse(result, Message: "Get slot by id successfull"));
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }
    }
}
