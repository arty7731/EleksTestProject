using AutoMapper;
using EleksProject.Core.Dto;
using EleksProject.Core.Enums;
using EleksProject.Core.Exceptions;
using EleksProject.Core.Interfaces.Business;
using EleksProject.Core.Interfaces.Repository;
using EleksProject.Core.Interfaces.UnitOfWork;
using System.ComponentModel.DataAnnotations;

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
            if(!customerId.HasValue && string.IsNullOrEmpty(customerEmail))
            {
                throw new CustomerException(CustomerErrorCode.NoInquiryCriteria);
            }

            if (customerId.HasValue)
            {
                bool isExists = this.customerRepository.IsExistsCustomerById(customerId.Value);
                if (!isExists)
                {
                    throw new CustomerException(CustomerErrorCode.InvalidCustomerId);
                }
            }

            if (!string.IsNullOrEmpty(customerEmail))
            {
                var isValid = new EmailAddressAttribute().IsValid(customerEmail);
                if (!isValid)
                {
                    throw new CustomerException(CustomerErrorCode.InvalidEmail);
                }

                bool isExists = this.customerRepository.IsExistsCustomerByEmail(customerEmail);
                if (!isExists)
                {
                    throw new CustomerException(CustomerErrorCode.InvalidEmail);
                }
            }

            CustomerDto customer = this.customerRepository.GetCustomerWithLastTransactions(customerId, customerEmail, CustomerManager.TakeLastTransactionsCount);
            return customer;
        }
    }
}
