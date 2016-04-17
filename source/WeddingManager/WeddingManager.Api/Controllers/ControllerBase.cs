using System.Web.Http;
using Hyjynx.DI;

namespace WeddingManager.Api.Controllers
{
    public class ControllerBase : ApiController
    {
        protected IHub Services
        {
            get
            {
                if(_services == null)
                {
                    _services = new Hub();
                }

                return _services;
            }
        }

        private IHub _services;
    }
}