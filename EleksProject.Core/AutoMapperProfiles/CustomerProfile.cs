using AutoMapper;
using EleksProject.Core.Dto;
using EleksProject.Core.Model;

namespace EleksProject.Core.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            this.CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Transactions, opt => opt.MapFrom(src => src.Transaction));
        }
    }
}
