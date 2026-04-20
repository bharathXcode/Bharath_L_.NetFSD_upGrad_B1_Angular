
using Microsoft.EntityFrameworkCore;
using PassengerService.Data;
using PassengerService.Repositories;

namespace PassengerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<PassengerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("PassengerConnection")));
            builder.Services.AddTransient<IPassengerRepository, PassengerRepository>();
            builder.Services.AddTransient<PassengerService.Services.IPassengerService,PassengerService.Services.PassengerService>();
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(cts => { },AppDomain.CurrentDomain.GetAssemblies());
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            

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
