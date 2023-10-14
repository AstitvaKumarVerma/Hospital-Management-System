using HMS_Web_APIs.Models.RequestModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;

namespace HMS_Web_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly StripeSetting _stripe;
        public StripeController(IConfiguration configuration, IOptions<StripeSetting> stripe)
        {
            _stripe = stripe.Value;
        }


        [HttpPost("charge")]
        public IActionResult Charge([FromBody] PaymentRequestDto pay)
        {
            StripeConfiguration.ApiKey = _stripe.SecretKey;
            try
            {
                int amo = Convert.ToInt32(pay.Amount);

                var optionss = new Stripe.Checkout.SessionCreateOptions
                {
                    PaymentMethodTypes = new List<string>
                    {
                        "card"
                    },
                    LineItems = new List<SessionLineItemOptions>
                    {
                        new SessionLineItemOptions
                        {
                            
                            PriceData = new SessionLineItemPriceDataOptions
                            {
                                
                                UnitAmount = amo * 100,
                                Currency = "inr",
                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Book Appoinment",
                                    Description = "Always for You",
                                },
                                
                            },
                            Quantity = 1,
                        },
                    },
                    Mode = "payment",
                    SuccessUrl = "http://localhost:4200/dash/patients/success-payment",
                    CancelUrl = "http://localhost:4200/dash/patients/fail-payment",
                };

                var service = new Stripe.Checkout.SessionService();
                Stripe.Checkout.Session session = service.Create(optionss);
                Response.Headers.Add("Location", session.Url);

                return Ok(session);
            }
            catch (Exception ex)
            {

                return BadRequest(new { Message = "Payment failed", Error = ex.Message });
            }
        }
    }
}
