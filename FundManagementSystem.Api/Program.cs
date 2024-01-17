using FundManagementSystem.Api.Middleware;
using FundManagementSystem.Application;
using FundManagementSystem.Identity;
using FundManagementSystem.Infrastructure;
using FundManagementSystem.Persistence;
using Microsoft.AspNetCore.RateLimiting;
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

            builder.Services.AddRateLimiter(_ => _.AddFixedWindowLimiter(policyName: "fixed_rate_limiter", options =>
            {
                options.PermitLimit = 6;
                options.Window = TimeSpan.FromSeconds(10);
                options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 2;
            }));

            builder.Services.AddRateLimiter(_ => _.AddConcurrencyLimiter(policyName: "concurrency_rate_limiter", options =>
            {
                options.PermitLimit = 4;
                options.QueueProcessingOrder = System.Threading.RateLimiting.QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 2;
            }));

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);
            builder.Services.AddPersistenceServices(builder.Configuration);
            //builder.Services.AddIdentityServices(builder.Configuration);

            var app = builder.Build();

            /*
             * Using API Key to protect the controllers
             */
            //app.UseApiKey();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

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