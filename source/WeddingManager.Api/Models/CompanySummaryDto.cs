using WeddingManager.Core.Data;

namespace WeddingManager.Api.Models
{
    public class CompanySummaryDto
    {
        public decimal AmountExpectedYearToDate { get; set; }

        public decimal AmountReceivedYearToDate { get; set; }

        public int UpcomingAppointmentCount { get; set; }

        public CompanySummaryDto(CompanySummary companySummary)
        {
            AmountExpectedYearToDate = companySummary.AmountExpectedYearToDate;

            AmountReceivedYearToDate = companySummary.AmountReceivedYearToDate;

            UpcomingAppointmentCount = companySummary.UpcomingAppointmentCount;
        }
    }
}