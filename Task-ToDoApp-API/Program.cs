using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Task_ToDo_API_BAL.ITodoServices;
using Task_ToDo_API_BAL.ToDoServices;
using Task_ToDo_API_DAL.ApplicationDbContext;
using Task_ToDo_API_DAL.IRepositories;
using Task_ToDo_API_DAL.Repositories;

namespace Task_ToDoApp_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Custom services in IOC Container 
            builder.Services.AddScoped<IToDoRepository, ToDoRepository>();
            builder.Services.AddScoped<ITodoTaskService, ToDoTaskService>();
            builder.Services.AddControllers();

            // Add CORS policy to allow requests from all origins
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder
                        .AllowAnyOrigin() // Allow requests from any origin
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            // Configure Swagger/OpenAPI
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Use CORS
            app.UseCors();

            app.MapControllers();

            app.Run();
        }
    }
}
