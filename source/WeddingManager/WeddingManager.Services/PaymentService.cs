using System.Collections.Generic;
using WeddingManager.Core.Data;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;

namespace WeddingManager.Services
{
    public class PaymentService : IPaymentService
    {
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public int CreatePayment(int serviceId, Payment payment)
        {
            return _paymentRepository.CreatePayment(serviceId, payment);
        }

        public IEnumerable<Payment> RetrievePayments(int serviceId)
        {
            return _paymentRepository.RetrievePayments(serviceId);
        }

        public void UpdatePayment(Payment payment)
        {
            _paymentRepository.UpdatePayment(payment);
        }

        public void DeletePayment(int paymentId)
        {
            _paymentRepository.DeletePayment(paymentId);
        }

        private readonly IPaymentRepository _paymentRepository;
    }
}