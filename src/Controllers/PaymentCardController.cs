using Microsoft.AspNetCore.Mvc;
using static src.DTO.PaymentCardDTO;
using src.Services.PaymentCard;

namespace src.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController] 
    public class PaymentCardController : ControllerBase
    {
        protected readonly IPaymentCardService _paymentCardService;

        public PaymentCardController(IPaymentCardService service)
        {
            _paymentCardService = service;
        }
        
        [HttpPost]
        public async Task<ActionResult<PaymentCardCreateDto>> CreateOne(PaymentCardCreateDto createDto)
        {
            var paymentCardCreated = await _paymentCardService.CreateOneAsync(createDto);
            return Ok(paymentCardCreated);
        }

        [HttpGet]
        public async Task<ActionResult<PaymentCardReadDto>> GetAllAsync()
        {
            var paymentCardList = await _paymentCardService.GetAllAsync();
            return Ok(paymentCardList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentCardReadDto>> GetByIdAsync(Guid id)
        {
            var foundPaymentCard = await _paymentCardService.GetByIdAsync(id);
            return Ok(foundPaymentCard);
        }

    }
}