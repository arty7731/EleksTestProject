using EleksProject.Core.Dto;

namespace EleksProject.Core.Interfaces.Business
{
    public interface ICustomerManager
    {
        CustomerDto GetCustomer(int? customerId, string customerEmail);
    }
}
