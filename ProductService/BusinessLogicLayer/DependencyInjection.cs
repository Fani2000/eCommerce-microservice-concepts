using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ProductService.BusinessLogicLayer.Mapper;
using ProductService.BusinessLogicLayer.ServiceContracts;
using ProductService.BusinessLogicLayer.Service;
using ProductService.BusinessLogicLayer.Validators;
using ProductsService.DataAccessLayer.Validators;

namespace ProductService.BusinessLogicLayer.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        //TO DO: Add Business Logic Layer services into the IoC container
        services.AddAutoMapper(typeof(ProductAddRequestToProductMappingProfile).Assembly);
        services.AddAutoMapper(typeof(ProductToProductResponseMappingProfile).Assembly);
        services.AddAutoMapper(typeof(ProductUpdateRequestToProductMappingProfile).Assembly);
        
        services.AddValidatorsFromAssemblyContaining<ProductAddRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<ProductUpdateRequestValidator>();
        
        services.AddScoped<IProductsService, Service.ProductsService>();
        
        return services;
    }
}