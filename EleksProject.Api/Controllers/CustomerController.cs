using AutoMapper;
using EleksProject.Api.Models.Customer.Request;
using EleksProject.Api.Models.Customer.Response;
using EleksProject.Core.Dto;
using EleksProject.Core.Exceptions;
using EleksProject.Core.Interfaces.Business;
using System.Web.Http;

namespace EleksProject.Api.Controllers
{
    [RoutePrefix("api/customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerManager customerManager;
        private readonly IMapper mapper;

        public CustomerController(ICustomerManager customerManager, IMapper mapper)
        {
            this.customerManager = customerManager;
            this.mapper = mapper;
        }

        [HttpPost, Route("")]
        public IHttpActionResult GetCustomerWithLastTransactions([FromBody]GetCustomerWithLastTransactionsRequest request)
        {
            IHttpActionResult result = null;

            try
            {
                CustomerDto customer = this.customerManager.GetCustomer(request.CustomerId, request.Email);

                if (customer != null)
                {
                    GetCustomerWithLastTransactionsResponse customerResponse = this.mapper.Map<CustomerDto, GetCustomerWithLastTransactionsResponse>(customer);
                    result = Json(customerResponse);
                }
                else
                {
                    result = BadRequest("Not found.");
                }
            }
            catch (CustomerException ex)
            {
                result = this.BadRequest(ex.Message);
            }
            catch
            {
                result = this.BadRequest();
            }

            return result;
        }
    }
}