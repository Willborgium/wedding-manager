using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class SummaryService : ISummaryService
    {
        public SummaryService(ISummaryRepository summaryRepository)
        {
            _summaryRepository = summaryRepository;
        }

        public CompanySummary RetrieveCompanySummary(int companyId)
        {
            return _summaryRepository.RetrieveCompanySummary(companyId);
        }

        public ExpensesSummary RetrieveExpensesSummary(int companyId)
        {
            return _summaryRepository.RetrieveExpensesSummary(companyId);
        }

        private readonly ISummaryRepository _summaryRepository;
    }
}