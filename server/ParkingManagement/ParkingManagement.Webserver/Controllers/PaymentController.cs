using Microsoft.AspNetCore.Mvc;
using ParkingManagement.Application.DTOs;
using ParkingManagement.Application.Services;

namespace ParkingManagement.Webserver.Controllers
{
    [ApiController]
    [Route("api/payments")]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPaymentsAsync(int pageIndex, int pageSize)
        {
            try
            {
                var result = await _paymentService.GetAllPaymentsAsync(pageIndex, pageSize);
                return Ok(new ServerResponse(result, true, "Payments retrieved successfully"));
            }
            catch(Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }


        [HttpPost]
        public async Task<IActionResult> Create(PaymentDto dto)
        {
            try
            {
                var result = await _paymentService.CreatePaymentAsync(dto);
                if(result == null)
                {
                    return BadRequest(new ServerResponse(null, false, "Payment creation failed"));
                }
                return Ok(new ServerResponse(result, true, "Payment created successfully"));
            }
            catch (Exception ex)
            {
                return BadRequest(new ServerResponse(null, false, ex.Message));
            }
        }
    }
}
