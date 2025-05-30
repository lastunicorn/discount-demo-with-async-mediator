using AsyncMediator.Extensions.DependencyInjection;
using DiscountDemo.Adapter.DataAccess;
using DiscountDemo.Application.CalculateDiscount;
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
        ConfigureServices(builder.Services);

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

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        Assembly presentationAssembly = typeof(DiscountController).Assembly;
        services.AddMvc().AddApplicationPart(presentationAssembly).AddControllersAsServices();

        Assembly useCaseAssembly = typeof(CalculateDiscountCriteria).Assembly;
        services.AddAsyncMediator(useCaseAssembly);

        services.AddSingleton<ICustomerRepository, CustomerRepository>();
    }
}
