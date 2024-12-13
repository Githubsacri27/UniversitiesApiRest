using Microsoft.EntityFrameworkCore;
using UniversitiesApp.Infrastructure.Contracts;
using UniversitiesApp.Infrastructure.Impl;
using UniversitiesApp.Infrastructure.Impl.DbContexts;
using UniversitiesApp.Library.Contracts;
using UniversitiesApp.Library.Impl;

namespace UniversitiesApp.DistributedService.WebApi
{
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

            var connectionString = builder.Configuration.GetConnectionString("UniversityDB");
            builder.Services.AddDbContext<UniversityDBContext>(options =>
                options.UseSqlServer(connectionString));

            // UniversityRepository y UniversityService
            builder.Services.AddScoped<IUniversityService, UniversityService>();
            builder.Services.AddHttpClient<IUniversityRepository, UniversityRepository>();

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
}
