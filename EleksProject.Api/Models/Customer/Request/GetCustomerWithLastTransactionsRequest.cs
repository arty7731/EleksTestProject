using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EleksProject.Api.Models.Customer.Request
{
    public class GetCustomerWithLastTransactionsRequest
    {
        public int? CustomerId { get; set; }
        public string Email { get; set; }
    }
}