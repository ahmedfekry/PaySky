using Microsoft.EntityFrameworkCore;
using PaySky.DataAccess;
using PaySky.DataAccess.Repository;
using PaySky.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PaySky.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            //Authentication & authorization
            builder.Services.AddAuthentication().AddJwtBearer();
            builder.Services.AddAuthorization();

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<PaySkyDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IVacancyRepsitory, VacancyRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

            app.MapControllers();

            app.Run();
        }
    }
}