using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/summaries")]
    public class SummaryController : ControllerBase
    {
        [HttpGet]
        [Route("company/{companyId}")]
        public async Task<IHttpActionResult> RetrieveCompanySummary(int companyId)
        {
            var companySummary = SummaryService.RetrieveCompanySummary(companyId);

            return Ok(new CompanySummaryDto(companySummary));
        }

        [HttpGet]
        [Route("expenses/{companyId}")]
        public async Task<IHttpActionResult> RetrieveExpensesSummary(int companyId)
        {
            var expensesSummary = SummaryService.RetrieveExpensesSummary(companyId);

            return Ok(new ExpensesSummaryDto(expensesSummary));
        }

        private ISummaryService SummaryService
        {
            get
            {
                return Services.Resolve<ISummaryService>();
            }
        }
    }
}