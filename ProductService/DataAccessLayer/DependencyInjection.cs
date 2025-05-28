using eCommerce.DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsService.DataAccessLayer.Context;
using ProductsService.DataAccessLayer.Repositories;

namespace ProductsService.DataAccessLayer;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        //TO DO: Add Data Access Layer services into the IoC container
        
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseMySQL(configuration.GetConnectionString("DefaultConnection")!);
        });

        
        services.AddScoped<IProductsRepository, ProductsRepository>();
        
        return services;
    }
}
