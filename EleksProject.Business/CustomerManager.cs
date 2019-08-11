using AutoMapper;
using EleksProject.Core.Dto;
using EleksProject.Core.Interfaces.Business;
using EleksProject.Core.Interfaces.Repository;
using EleksProject.Core.Interfaces.UnitOfWork;

namespace EleksProject.Business
{
    public class CustomerManager : ManagerBase, ICustomerManager
    {
        private const int TakeLastTransactionsCount = 5;

        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerManager(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) 
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public CustomerDto GetCustomer(int? customerId, string customerEmail)
        {
            CustomerDto customer = this.customerRepository.GetCustomerWithLastTransactions(customerId, customerEmail, CustomerManager.TakeLastTransactionsCount);
            return customer;
        }
    }
}
