namespace EleksProject.Data.Database
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using EleksProject.Core.Interfaces.DbContext;
    using EleksProject.Core.Model;

    public partial class DatabaseModel : DbContext, IDataContext
    {
        public DatabaseModel()
            : base("name=DatabaseModel")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.CustomerName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.ContactEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.MobileNo)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.CurrencyCode)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Status)
                .IsUnicode(false);
        }
    }
}
