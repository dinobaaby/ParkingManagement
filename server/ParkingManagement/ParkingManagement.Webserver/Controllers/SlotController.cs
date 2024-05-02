using AutoMapper;
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
        private readonly IMapper _mapper;

        public SlotController(ISlotService slotService, IMapper mapper)
        {
            _slotService = slotService;
            _mapper = mapper;
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
        [HttpGet("GetSlotByName/{name}")]
        public async Task<IActionResult> GetSlotByName(string name, int pageIndex, int pageSize) 
        {
            try
            {
                var result = await _slotService.GetSlotByNameAsync(name, pageIndex, pageSize);
                return Ok(new ServerResponse(result, Message: "Get slot by name successfull"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(Slot slot)
        {
            try
            {
                bool isSuccess = await _slotService.UpdateSlotAsync(slot);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(slot, Message: "Updated"));
                }
                return BadRequest(new ServerResponse(null, false, "Faild"));
            }catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccess = await _slotService.DeleteSlotAsync(id);
                if (isSuccess)
                {
                    return Ok(new ServerResponse(null, Message: "Deleted"));
                }
                return BadRequest(new ServerResponse(null, Message: "Faild"));
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

    }
}
