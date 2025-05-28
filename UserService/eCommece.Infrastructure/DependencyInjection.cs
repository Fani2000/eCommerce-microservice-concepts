using eCommece.Infrastructure.DbContext;
using eCommece.Infrastructure.Repository;
using eCommerce.Core.RepositoryContracts;
using Microsoft.Extensions.DependencyInjection;

namespace eCommece.Infrastructure;

public static class DependencyInjection
{
    /// <summary>
    /// Extension method to add infrastructure services to the dependency injection container
    /// </summary>
    /// <param name="services"></param>
    /// <returns></returns>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
       // TODO: Add Service to the IoC container 

       services.AddSingleton<IUsersRepository, UsersRepository>();

       services.AddTransient<DapperDbContext>();
       
       return services; 
    }
}