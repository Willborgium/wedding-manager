using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/payments")]
    public class PaymentController : ControllerBase
    {
        [HttpPost]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> CreatePayment(int serviceId, [FromBody]PaymentDto payment)
        {
            var paymentId = PaymentService.CreatePayment(serviceId, payment.ToPayment());

            return Ok(paymentId);
        }

        [HttpGet]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> RetrievePayments(int serviceId)
        {
            var payments = PaymentService.RetrievePayments(serviceId).Select(p => new PaymentDto(p));

            return Ok(payments);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdatePayment([FromBody]PaymentDto payment)
        {
            PaymentService.UpdatePayment(payment.ToPayment());

            return Ok();
        }

        [HttpDelete]
        [Route("{paymentId}")]
        public async Task<IHttpActionResult> DeletePayment(int paymentId)
        {
            PaymentService.DeletePayment(paymentId);

            return Ok();
        }

        protected IPaymentService PaymentService
        {
            get
            {
                return Services.Resolve<IPaymentService>();
            }
        }
    }
}