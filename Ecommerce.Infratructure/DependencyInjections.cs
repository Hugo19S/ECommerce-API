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

        //services.AddScoped<ICartRepository, >();
        //services.AddScoped<ICategoryRepository, >();
        services.AddScoped<IMakerRepostory, MakerRepository>();
        /*services.AddScoped<IOrderItemsRepository, >();
        services.AddScoped<IOrderRepository, >();*/
        services.AddScoped<IPaymentMethodRepository, PaymentMethodRepository>();
        //services.AddScoped<IPaymentRepository, >();
        //services.AddScoped<IProductDiscountRepository, >();
        //services.AddScoped<IProductImageRepository, >();
        //services.AddScoped<IProductPriceRepository, >();
        //services.AddScoped<IProductRepository, >();
        //services.AddScoped<ISellerRepository, >();
        services.AddScoped<IStatusRepository, StatusRepository>();
        //services.AddScoped<ISubCategoryRepository, >();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork>(s => s.GetRequiredService<ECommerceDbContext>());
        return services;
    }
}
