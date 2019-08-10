namespace EleksProject.Core.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(30)]
        public string CustomerName { get; set; }

        [Required]
        [StringLength(25)]
        public string ContactEmail { get; set; }

        [Required]
        [StringLength(10)]
        public string MobileNo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
