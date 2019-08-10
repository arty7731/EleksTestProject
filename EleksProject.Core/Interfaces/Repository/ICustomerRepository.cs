using EleksProject.Core.Interfaces.Repositories;
using EleksProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Core.Interfaces.Repository
{
    public interface ICustomerRepository : IRepositoryBase<Customer>
    {
        Customer GetCustomer(int customerId);
    }
}
