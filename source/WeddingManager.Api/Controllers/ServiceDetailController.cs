using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/serviceDetails")]
    public class ServiceDetailController : ControllerBase
    {
        [HttpOptions]
        [Route("")]
        public async Task<IHttpActionResult> Options()
        {
            return Ok();
        }

        [HttpOptions]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> Options(int serviceId)
        {
            return Ok();
        }

        [HttpPost]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> CreateServiceDetail(int serviceId, [FromBody]ServiceDetailDto serviceDetailDto)
        {
            var serviceDetailId = ServiceDetailService.CreateServiceDetail(serviceId, serviceDetailDto.ToServiceDetail());

            return Ok(serviceDetailId);
        }

        [HttpGet]
        [Route("{serviceId}")]
        public async Task<IHttpActionResult> RetrieveServiceDetails(int serviceId)
        {
            var serviceDetails = ServiceDetailService.RetrieveServiceDetails(serviceId).Select(sd => new ServiceDetailDto(sd));

            return Ok(serviceDetails);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateServiceDetail([FromBody]ServiceDetailDto serviceDetailDto)
        {
            ServiceDetailService.UpdateServiceDetail(serviceDetailDto.ToServiceDetail());

            return Ok();
        }

        [HttpDelete]
        [Route("{serviceDetailId}")]
        public async Task<IHttpActionResult> DeleteServiceDetail(int serviceDetailId)
        {
            ServiceDetailService.DeleteServiceDetail(serviceDetailId);

            return Ok();
        }

        protected IServiceDetailService ServiceDetailService
        {
            get
            {
                return Services.Resolve<IServiceDetailService>();
            }
        }
    }
}