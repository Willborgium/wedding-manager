using System.Collections.Generic;
using WeddingManager.Core.Data;

namespace WeddingManager.Core.Repositories
{
    public interface IPaymentRepository
    {
        int CreatePayment(int serviceId, Payment payment);

        IEnumerable<Payment> RetrievePayments(int serviceId);

        void UpdatePayment(Payment payment);

        void DeletePayment(int paymentId);
    }
}