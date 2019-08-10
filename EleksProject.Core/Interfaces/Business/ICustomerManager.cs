using EleksProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EleksProject.Core.Interfaces.Business
{
    public interface ICustomerManager
    {
        Customer GetCustomer(int customerId);
    }
}
