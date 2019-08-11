using System;

namespace EleksProject.Core.Dto
{
    public class TransactionDto
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string CurrencyCode { get; set; }
        public string Status { get; set; }
    }
}
