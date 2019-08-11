using System.Collections.Generic;

namespace EleksProject.Core.Dto
{
    public class CustomerDto
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string ContactEmail { get; set; }
        public string MobileNo { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}
