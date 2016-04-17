using System.Web.Http;
using Hyjynx.DI;
using WeddingManager.Core.Repositories;
using WeddingManager.Core.Services;
using WeddingManager.Repositories;
using WeddingManager.Services;

namespace WeddingManager.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            Hub.CreateResolverStatic<ICompanyService, CompanyService>();

            Hub.CreateResolverStatic<ICompanyRepository, CompanyRepository>();

            Hub.CreateResolverStatic<IExpenseRepository, ExpenseRepository>();

            Hub.CreateResolverStatic<IExpenseService, ExpenseService>();

            Hub.CreateResolverStatic<ICustomerRepository, CustomerRepository>();

            Hub.CreateResolverStatic<ICustomerService, CustomerService>();

            Hub.CreateResolverStatic<IServiceRepository, ServiceRepository>();

            Hub.CreateResolverStatic<IServiceService, ServiceService>();

            Hub.CreateResolverStatic<IInvoiceRepository, InvoiceRepository>();

            Hub.CreateResolverStatic<IInvoiceService, InvoiceService>();

            Hub.CreateResolverStatic<IPaymentRepository, PaymentRepository>();

            Hub.CreateResolverStatic<IPaymentService, PaymentService>();
        }
    }
}