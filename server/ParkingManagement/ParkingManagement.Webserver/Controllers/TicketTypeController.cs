using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;
using ParkingManagement.Domain.Entities;

namespace ParkingManagement.Webserver.Controllers
{
    [Route("api/tickettype")]
    [ApiController]
    public class TicketTypeController : Controller
    {
        private readonly ITicketTypeService _ticketTypeService;
        public TicketTypeController(ITicketTypeService ticketTypeService)
        {
            _ticketTypeService = ticketTypeService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TicketType ticketType)
        {
            try
            {
                var result = await _ticketTypeService.CreateTicketTypeAsync(ticketType);
                return Ok(new ServerResponse(result, true, "Ticket Type Created Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTicketTypes(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _ticketTypeService.GetAllTicketTypesAsync(pageIndex, pageSize);
                return Ok(new ServerResponse(result, true, "Ticket Types Retrieved Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketTypeById(int id)
        {
            try
            {
                var result = await _ticketTypeService.GetTicketTypeByIdAsync(id);
                return Ok(new ServerResponse(result, true, "Ticket Type Retrieved Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(TicketType model)
        {
            try
            {
                bool isSuccessful = await _ticketTypeService.UpdateTicketTypeAsync(model);
                if (isSuccessful)
                {
                    return Ok(new ServerResponse(null, true, "Ticket Type Updated Successfully"));
                }
                return BadRequest(new ServerResponse(null, false, "Ticket Type Update Failed"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                bool isSuccessful = await _ticketTypeService.DeleteTicketTypeAsync(id);
                if (isSuccessful)
                {
                    return Ok(new ServerResponse(null, true, "Ticket Type Deleted Successfully"));
                }

                return BadRequest(new ServerResponse(null, false, "Ticket Type Delete Failed"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

        [HttpGet("GetTicketTypeByName/{name}")]
        public async Task<IActionResult> GetTicketTypeByName(string name, int pageIndex, int pageSize)
        {
            try
            {
                var result = await _ticketTypeService.GetTicketTypesByNameAsync(name, pageIndex, pageSize);
                return Ok(new ServerResponse(result, true, "Ticket Type Retrieved Successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }

    }
}
