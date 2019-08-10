namespace EleksProject.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Transaction")]
    public partial class Transaction
    {
        public int TransactionId { get; set; }

        public DateTime TransactionDate { get; set; }

        public decimal Amount { get; set; }

        [Required]
        [StringLength(5)]
        public string CurrencyCode { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
