using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface ISummaryRepository
    {
        CompanySummary RetrieveCompanySummary(int companyId);

        ExpensesSummary RetrieveExpensesSummary(int companyId);
    }
}