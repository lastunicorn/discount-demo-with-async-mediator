using AsyncMediator.Extensions.DependencyInjection;
using DiscountDemo.Adapter.EfDataAccess;
using DiscountDemo.Application.CalculateDiscount;
using DiscountDemo.Port.DataAccess;
using DiscountDemo.Presentation.Controllers;
using DiscountDemo.Presentation.ErrorHandling;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CustomerRepository = DiscountDemo.Adapter.EfDataAccess.CustomerRepository;

namespace DiscountDemo;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Configure EF Core
        builder.Services.AddDbContext<DiscountDemoDbContext>(options =>
        {
            string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        Assembly presentationAssembly = typeof(DiscountController).Assembly;
        builder.Services.AddMvc().AddApplicationPart(presentationAssembly).AddControllersAsServices();

        Assembly useCaseAssembly = typeof(CalculateDiscountCriteria).Assembly;
        builder.Services.AddAsyncMediator(useCaseAssembly);

        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

        builder.Services.AddExceptionHandlers(presentationAssembly);

        var app = builder.Build();

        app.UseExceptionHandlers();

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