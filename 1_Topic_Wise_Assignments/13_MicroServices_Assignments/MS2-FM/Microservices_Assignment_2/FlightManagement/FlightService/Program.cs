
using FlightService.Data;
using FlightService.Service;
using FlightService.Services;
using Microsoft.EntityFrameworkCore;

namespace FlightService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            // Add services to the container.
            builder.Services.AddDbContext<FlightDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("FlightConnection")));
            builder.Services.AddControllers();
            builder.Services.AddTransient<IFlightRepository, FlightRepository>();
            builder.Services.AddTransient<FlightService.Services.IFlightService, FlightService.Services.FlightService>();
            builder.Services.AddAutoMapper(cts => { }, AppDomain.CurrentDomain.GetAssemblies());
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
