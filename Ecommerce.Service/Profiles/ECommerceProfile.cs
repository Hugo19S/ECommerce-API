using AutoMapper;
using Ecommerce.Domain.Entities;
using Ecommerce.Service.Contracts;

namespace Ecommerce.Service.Profiles
{
    
    public class ECommerceProfile : Profile
    {
        public ECommerceProfile()
        {
            /* Category Profile */
            CreateMap<Category, CategoryResponse>();
            CreateMap<Category, List<CategoryResponse>>();

            /* Maker Profile */
            CreateMap<Maker, GetMakerResponse>();
            CreateMap<Maker, List<GetMakerResponse>>();

            /* User Profile */
            CreateMap<User, UserResponse>();
            CreateMap<User, List<UserResponse>>();

            /* PaymentMethod Profile */
            CreateMap<PaymentMethod, PaymentMethodResponse>();
            CreateMap<PaymentMethod, List<PaymentMethodResponse>>();
        }
    }
}
