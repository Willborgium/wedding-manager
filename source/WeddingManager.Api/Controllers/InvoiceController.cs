using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/invoices")]
    public class InvoiceController : ControllerBase
    {
        [HttpOptions]
        [Route("")]
        public async Task<IHttpActionResult> Options()
        {
            return Ok();
        }

        [HttpOptions]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> Options(int companyId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> CreateInvoices(int serviceId, [FromBody]InvoiceDto invoiceDto)
        {
            var invoiceId = InvoiceService.CreateInvoice(serviceId, invoiceDto.ToInvoice());

            return Ok(invoiceId);
        }

        [HttpGet]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> RetrieveInvoices(int serviceId)
        {
            var invoices = InvoiceService.RetrieveInvoices(serviceId).Select(i => new InvoiceDto(i));

            return Ok(invoices);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateInvoice([FromBody]InvoiceDto invoiceDto)
        {
            InvoiceService.UpdateInvoice(invoiceDto.ToInvoice());

            return Ok();
        }

        [HttpDelete]
        [Route("{invoiceId}")]
        public async Task<IHttpActionResult> DeleteInvoice(int invoiceId)
        {
            InvoiceService.DeleteInvoice(invoiceId);

            return Ok();
        }

        protected IInvoiceService InvoiceService
        {
            get
            {
                return Services.Resolve<IInvoiceService>();
            }
        }
    }
}