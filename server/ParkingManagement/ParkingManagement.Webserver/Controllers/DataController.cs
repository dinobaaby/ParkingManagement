using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Domain.Entities;
using ParkingManagement.Infrastucture.Data;

namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/data")]
    public class DataController : Controller
    {
        private readonly ApplicationDbContext _context;
        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            try
            {
                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("TicketData")]
        public async Task<IActionResult> TicketData()
        {
            try
            {
                for (int i = 0; i < 50; i++)
                {
                    Slot slot = new Slot
                    {
                        SlotName = "A2" + i, 
                        SlotId = 0,
                        AreaId = 3,
                        SlotType = 2
                    };

                    _context.Slot.Add(slot);
                    await _context.SaveChangesAsync(); 

                    Ticket ticket = new Ticket
                    {
                        TicketId = 0,
                        IssueDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddDays(1),
                        TicketTypeId = 1,
                        TicketStatus = 1,
                        PlateNumber = "null",
                        VehicleImage = "null",
                        SlotId = slot.SlotId 
                    };

                    _context.Tickets.Add(ticket);
                    await _context.SaveChangesAsync();
                }
                

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
