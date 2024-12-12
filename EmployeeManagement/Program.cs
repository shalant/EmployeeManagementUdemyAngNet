using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using EmployeeManagement.Data;

namespace EmployeeManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<AppDbContext>(
                options => options.UseInMemoryDatabase("EmployeeDb"));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyCors", builder =>
                {
                    builder.WithOrigins("https://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            var app = builder.Build();

            app.MapGet("/", () => "Hello World!");

            app.UseCors("MyCors");

            app.Run();
        }
    }
}
