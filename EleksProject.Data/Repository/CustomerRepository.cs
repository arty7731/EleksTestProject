using EleksProject.Core.Interfaces.Repository;
using EleksProject.Core.Interfaces.UnitOfWork;
using EleksProject.Core.Model;
using EleksProject.Data.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Data.Repository
{
    public class CustomerRepository : RepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            
        }

        public Customer GetCustomer(int customerId)
        {
            return this.Select().FirstOrDefault(c => c.CustomerId == customerId);
        }
    }
}
