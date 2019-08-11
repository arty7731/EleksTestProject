using AutoMapper;
using EleksProject.Api.Models.Customer.Response;
using EleksProject.Core.Dto;
using EleksProject.Core.Model;

namespace EleksProject.Api.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<CustomerDto, GetCustomerWithLastTransactionsResponse>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.ContactEmail))
                .ForMember(dest => dest.Mobile, opt => opt.MapFrom(src => src.MobileNo))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transactions));

            this.CreateMap<TransactionDto, GetCustomerWithLastTransactionsResponse.Transaction>()
                .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.CurrencyCode))
                .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.TransactionDate))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TransactionId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status));

        }
    }
}
