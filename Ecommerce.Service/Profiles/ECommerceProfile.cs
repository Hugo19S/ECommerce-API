﻿using AutoMapper;
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

            /* Maker Profile */
            CreateMap<Maker, GetMakerResponse>();

            /* Order Profile */
            CreateMap<Order, OrderResponse>();
            CreateMap<OrderStatusHistory, OrderHistoryResponse>();
            
            /* PaymentMethod Profile */
            CreateMap<PaymentMethod, PaymentMethodResponse>();

            /* Seller Profile */
            CreateMap<Seller, SellerResponse>();

            /* SubCategory Profile */
            CreateMap<SubCategory, SubCategoryResponse>();

            /* User Profile */
            CreateMap<User, UserResponse>();
        }
    }
}
