using BarberHouse.Database;
using BarberHouse.Models;
using BarberHouse.Repositories.Classes;
using BarberHouse.Repositories.Interfaces;
using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BarberHouse
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Database connection
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("connection")));
            // Dependencies
            builder.Services.AddScoped<IGroupRepository, GroupRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRegistrationRepository, RegistrationRepository>();
            builder.Services.AddScoped<ILoginRepository, LoginRepository>();
            builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
            builder.Services.AddScoped<IDateRepository, DateRepository>();
            builder.Services.AddScoped<IVisitRepository, VisitRepository>();
            /*builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();

            // Identity
            builder.Services.AddIdentity<User, Group>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();*/

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
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
