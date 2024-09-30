using Microsoft.AspNetCore.Mvc;
using static src.DTO.PaymentCardDTO;
using src.Services.PaymentCard;

namespace src.Controllers
{
    /// <API>
    /// POST: /api/v1/PaymentCard
    /// {
    ///     "cardHolderName": "string",
    ///     "cardType": "string",
    ///     "cardNumber": "string",
    ///     "expiryDate": "DateTime",
    ///     "billingAddress": "string"
    /// }
    /// Returns the created payment card information.
    ///
    /// GET: /api/v1/PaymentCard
    /// Returns the list of all payment cards.
    ///
    /// GET: /api/v1/PaymentCard/{PaymentCardId}
    /// Returns the details of the payment card associated with the given PaymentCardId.
    ///
    /// PUT: /api/v1/PaymentCard/{PaymentCardId}
    /// {
    ///     "cardHolderName": "string",
    ///     "cardType": "string",
    ///     "cardNumber": "string",
    ///     "expiryDate": "DateTime",
    ///     "billingAddress": "string"
    /// }
    /// Updates the payment card information for the given PaymentCardId.
    ///
    /// DELETE: /api/v1/PaymentCard/{PaymentCardId}
    /// Deletes the payment card associated with the given PaymentCardId.
    /// </API>

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

        [HttpGet("{PaymentCardId}")]
        public async Task<ActionResult<PaymentCardReadDto>> GetByIdAsync(Guid PaymentCardId)
        {
            var foundPaymentCard = await _paymentCardService.GetByIdAsync(PaymentCardId);
            return Ok(foundPaymentCard);
        }

        [HttpPut("{PaymentCardId}")]
        public async Task<ActionResult<PaymentCardReadDto>> UpdateOne(Guid PaymentCardId, PaymentCardUpdateDto updateDto)
        {
            var paymentCardUpdate = await _paymentCardService.UpdateOneAsync(PaymentCardId, updateDto);
            if (paymentCardUpdate == null)
            {
                return NotFound("Payment Card not found"); //400  Not Found
            }
            return Ok(paymentCardUpdate); //200 OK
        }

        [HttpDelete("{PaymentCardId}")]
        public async Task<ActionResult> DeleteOne(Guid PaymentCardId)
        {
            var paymentCardDeleted = await _paymentCardService.DeleteOneAsync(PaymentCardId);
            if (paymentCardDeleted == false)
            {
                return NotFound(); // 404 Not Found
            }
            return NoContent(); // 200 OK 
        }



    }
}
