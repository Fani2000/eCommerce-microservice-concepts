using System.Text.Json.Serialization;
using eCommece.Infrastructure;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(ops =>
{
    ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

// Auto_Mapper object mapping
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RegisterUserMappingProfile).Assembly);
builder.Services.AddAutoMapper(typeof(LoginUserMappingProfile).Assembly);

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();