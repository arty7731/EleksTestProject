using EleksProject.Core.Dto;
using EleksProject.Core.Interfaces.Repositories;
using EleksProject.Core.Model;

namespace EleksProject.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        CustomerDto GetCustomerWithLastTransactions(int? customerId, string customerEmail, int takeTransactionsCount);
    }
}
