using EleksProject.Core.Dto;
using EleksProject.Core.Interfaces.Repository;
using EleksProject.Core.Interfaces.UnitOfWork;
using EleksProject.Core.Model;
using EleksProject.Data.Shared;
using System;
using System.Linq;

namespace EleksProject.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public CustomerDto GetCustomerWithLastTransactions(int? customerId, string customerEmail, int takeTransactionsCount)
        {
            CustomerDto result = this.Where(c => (!customerId.HasValue || c.CustomerId == customerId.Value) 
                && (string.IsNullOrEmpty(customerEmail) || c.ContactEmail.Equals(customerEmail, StringComparison.InvariantCultureIgnoreCase)))
                .Select(c => new CustomerDto
                {
                    CustomerId = c.CustomerId,
                    ContactEmail = c.ContactEmail,
                    CustomerName = c.CustomerName,
                    MobileNo = c.MobileNo,
                    Transactions =  c.Transaction
                        .OrderByDescending(t => t.TransactionId)
                        .Take(takeTransactionsCount)
                        .Select(t => new TransactionDto
                        {
                            Amount = t.Amount,
                            TransactionId = t.TransactionId,
                            CurrencyCode = t.CurrencyCode,
                            Status = t.Status,
                            TransactionDate = t.TransactionDate
                        })
                })
                .FirstOrDefault();

            return result;
        }

        public bool IsExistsCustomerByEmail(string customerEmail)
        {
            return this.Select().Any(c => c.ContactEmail.Equals(customerEmail, StringComparison.InvariantCultureIgnoreCase));
        }

        public bool IsExistsCustomerById(int customerId)
        {
            return this.Select().Any(c => c.CustomerId == customerId);
        }
    }
}
