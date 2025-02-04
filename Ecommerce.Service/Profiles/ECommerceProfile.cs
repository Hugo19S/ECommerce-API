using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service.Profiles
{
    public class ECommerceProfile : Profile
    {
        public ECommerceProfile()
        {
            CreateMap<User, UserResponse>();
        }
    }
}
