using EleksProject.Api.CustomAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace EleksProject.Api.Models.Customer.Response
{
    public class GetCustomerWithLastTransactionsResponse
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public IEnumerable<GetCustomerWithLastTransactionsResponse.Transaction> Transactions { get; set; }

        public class Transaction
        {
            public int Id { get; set; }

            [JsonConverter(typeof(CustomDateTimeConverter))]
            public DateTime Date { get; set; }
            public decimal Amount { get; set; }
            public string Currency { get; set; }
            public string Status { get; set; }
        } 
    }

}