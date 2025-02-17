using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service.Profiles
{
    public class ECommerceProfile : Profile
    {
        public ECommerceProfile()
        {
            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, List<CategoryResponse>>();
            CreateMap<Maker, GetMakerResponse>();
            CreateMap<Maker, List<GetMakerResponse>>();
            CreateMap<User, UserResponse>();
        }
    }
}
