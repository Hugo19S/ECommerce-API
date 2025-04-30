using Ecommerce.Application.Common;
using Ecommerce.Application.IRepositories;
using Ecommerce.Infratructure.Repositories;

//using Ecommerce.Infratructure.Migrations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infratructure;

public static class DependencyInjections
{
    public static IServiceCollection AddInfrastructureDependency(this IServiceCollection services,
                                                                 IConfiguration configuration)
    {
        services.AddDbContext<ECommerceDbContext>(option => 
            option.UseNpgsql(configuration.GetConnectionString("ECommerce1")));

        services.AddScoped<ICartRepository, CartRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IMakerRepostory, MakerRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISellerRepository, SellerRespository>();
        services.AddScoped<IStatusRepository, StatusRepository>();
        services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICacheRepository, CacheRepository>();
        services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<ECommerceDbContext>());
        return services;
    }
}
