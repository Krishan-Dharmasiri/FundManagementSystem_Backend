using FundManagementSystem.Api.Middleware;
using FundManagementSystem.Application;
using FundManagementSystem.Infrastructure;
using FundManagementSystem.Persistence;
using Serilog;

namespace FundManagementSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateBootstrapLogger();

            Log.Information("Fund Management System API starting.");

            var builder = WebApplication.CreateBuilder(args);

            // Setup Serilog as the logging provider and look at the appsettings.json for configurations
            builder.Host.UseSerilog((context, LoggerConfiguration) => LoggerConfiguration.WriteTo.Console()
                            .ReadFrom.Configuration(context.Configuration));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("FMSAPI", builder => builder.AllowAnyOrigin()
                    .AllowAnyHeader().AllowAnyMethod());
            });

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            // Custom Middleware for exception handling
            app.UseCustomExceptionHandler();

            app.UseCors("FMSAPI");

            app.UseAuthorization();

            app.MapControllers();

            app.UseSerilogRequestLogging();

            app.Run();
        }
    }
}