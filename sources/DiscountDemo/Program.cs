using AsyncMediator.Extensions.DependencyInjection;
using DiscountDemo.Adapter.DataAccess;
using DiscountDemo.Application.Discount;
using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.Controllers;
using System.Reflection;

namespace DiscountDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        Assembly presentationAssembly = typeof(DiscountController).Assembly;
        builder.Services.AddMvc().AddApplicationPart(presentationAssembly).AddControllersAsServices();

        Assembly useCaseAssembly = typeof(DiscountCriteria).Assembly;
        builder.Services.AddAsyncMediator(useCaseAssembly);

        builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
