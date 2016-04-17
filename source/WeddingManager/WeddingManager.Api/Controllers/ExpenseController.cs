using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using WeddingManager.Api.Models;
using WeddingManager.Core.Services;

namespace WeddingManager.Api.Controllers
{
    [RoutePrefix("api/expenses")]
    public class ExpenseController : ControllerBase
    {
        [HttpPost]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> CreateExpense(int companyId, [FromBody]ExpenseDto expenseDto)
        {
            var expenseId = ExpenseService.CreateExpense(companyId, expenseDto.ToExpense());

            return Ok(expenseId);
        }

        [HttpGet]
        [Route("{companyId}")]
        public async Task<IHttpActionResult> RetrieveExpenses(int companyId)
        {
            var expenses = ExpenseService.RetrieveExpenses(companyId).Select(e => new ExpenseDto(e));

            return Ok(expenses);
        }

        [HttpPut]
        [Route("")]
        public async Task<IHttpActionResult> UpdateExpense([FromBody]ExpenseDto expenseDto)
        {
            ExpenseService.UpdateExpense(expenseDto.ToExpense());

            return Ok();
        }

        [HttpDelete]
        [Route("{expenseId}")]
        public async Task<IHttpActionResult> DeleteExpense(int expenseId)
        {
            ExpenseService.DeleteExpense(expenseId);

            return Ok();
        }

        protected IExpenseService ExpenseService
        {
            get
            {
                return Services.Resolve<IExpenseService>();
            }
        }
    }
}