using FluentValidation.AspNetCore;
using Products.API.ApiEndpoints;
using ProductService.BusinessLogicLayer.DependencyInjection;
using ProductService.BusinessLogicLayer.ServiceContracts;
using ProductsMicroService.API.Middleware;
using ProductsService.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

//Add DAL and BLL services
builder.Services.AddDataAccessLayer(builder.Configuration);
builder.Services.AddBusinessLogicLayer();

builder.Services.AddControllers();

//FluentValidations
builder.Services.AddFluentValidationAutoValidation();



//Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => {
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
var app = builder.Build();

app.UseExceptionHandlingMiddleware();
app.UseRouting();


//Cors
app.UseCors();

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapProductAPIEndpoints();
app.MapControllers();

app.Run();