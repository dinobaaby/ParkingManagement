using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/tickets")]
    public class TicketsController : Controller
    {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            try
            {
                var response = await _ticketService.GetTicketsAsync();
                return Ok(new ServerResponse(response, true, "Tickets retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpPatch("CheckIn/{ticketId}")]
        public async Task<IActionResult> CheckIn(int ticketId, string plateNumber, IFormFile file)
        {
            try
            {
                var response = await _ticketService.CheckInAsync(ticketId, plateNumber, file);
                return Ok(new ServerResponse(response, true, "Ticket checked in successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("GetByType/{ticketType}")]
        public async Task<IActionResult> GetTicketsByType(int ticketType)
        {
            try
            {
                var response = await _ticketService.GetTicketsByTypeAsync(ticketType);
                return Ok(new ServerResponse(response, true, "Tickets retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("GetByStatus/{ticketStatus}")]
        public async Task<IActionResult> GetTicketsByStatus(int ticketStatus)
        {
            try
            {
                var response = await _ticketService.GetTicketsByStatusAsync(ticketStatus);
                return Ok(new ServerResponse(response, true, "Tickets retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("GetByPlateNumber/{plateNumber}")]
        public async Task<IActionResult> GetTicketsByPlateNumber(string plateNumber)
        {
            try
            {
                var response = await _ticketService.GetTicketsByPlateNumberAsync(plateNumber);
                return Ok(new ServerResponse(response, true, "Tickets retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("GetBySlotId/{slotId}")]
        public async Task<IActionResult> GetTicketsBySlotId(int slotId)
        {
            try
            {
                var response = await _ticketService.GetTicketsBySlotIdAsync(slotId);
                return Ok(new ServerResponse(response, true, "Tickets retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }

        [HttpGet("{ticketId}")]
        public async Task<IActionResult> GetTicketById(int ticketId)
        {
            try
            {
                var response = await _ticketService.GetTicketByIdAsync(ticketId);
                return Ok(new ServerResponse(response, true, "Ticket retrieved successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateTicket([FromForm] TicketDto ticketDto, IFormFile file)
        {
            try
            {
                var response = await _ticketService.CreateTicketAsync(ticketDto, file);
                return Ok(new ServerResponse(response, true, "Ticket created successfully"));
            }
            catch (Exception e)
            {
                return BadRequest(new ServerResponse(null, false, e.Message));
            }
        }
    }
}
