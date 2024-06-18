using Azure;
using Coffee.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Net.payOS;
using Net.payOS.Types;

namespace Coffee.WebUI.Controllers
{
    public class PayOsController : Controller
    {
        private readonly PayOS _payOS;
        public PayOsController(PayOS payOS)
        {
            _payOS = payOS;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePaymentLink(CreatePaymentLinkRequest body)
        {
            try
            {
                int orderCode = int.Parse(DateTimeOffset.Now.ToString("ffffff"));
                ItemData item = new ItemData(body.productName, 1, body.price);
                List<ItemData> items = new List<ItemData>();
                items.Add(item);
                PaymentData paymentData = new PaymentData(orderCode, body.price, body.description, items, body.cancelUrl, body.returnUrl);

                CreatePaymentResult createPayment = await _payOS.createPaymentLink(paymentData);

                return Ok(new Models.Response(0, "success", createPayment));
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
                return Ok(new Models.Response(-1, "fail", null));
            }
        }
        [HttpPost("confirm-webhook")]
        public async Task<IActionResult> ConfirmWebhook(ConfirmWebhook body)
        {
            try
            {
                await _payOS.confirmWebhook(body.webhook_url);
                return Ok(new Models.Response(0, "Ok", null));
            }
            catch (System.Exception exception)
            {

                Console.WriteLine(exception);
                return Ok(new Models.Response(-1, "fail", null));
            }

        }
    }
}
