using AutoMapper;
using EleksProject.Core.Interfaces.Business;
using EleksProject.Core.Interfaces.Repository;
using EleksProject.Core.Interfaces.UnitOfWork;
using EleksProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Business
{
    public class CustomerManager : ManagerBase, ICustomerManager
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerManager(IUnitOfWork unitOfWork, IMapper mapper, ICustomerRepository customerRepository) 
            : base(unitOfWork)
        {
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        public Customer GetCustomer(int customerId)
        {
            return this.customerRepository.GetCustomer(customerId);
        }
    }
}
