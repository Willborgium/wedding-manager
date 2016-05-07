using WeddingManager.Core.Data;

namespace WeddingManager.Core.Services
{
    public interface ISummaryService
    {
        CompanySummary RetrieveCompanySummary(int companyId);

        ExpensesSummary RetrieveExpensesSummary(int companyId);
    }
}