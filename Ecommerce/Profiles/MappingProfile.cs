using AutoMapper;
using Ecommerce.Models;
using Ecommerce.Requests;

namespace Ecommerce.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<AddOrderRequest, Order>();
        CreateMap<AddProductRequest, Product>();
        CreateMap<AddCustomerRequest, Customer>();
    }
}