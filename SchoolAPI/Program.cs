
using Dal;
using Microsoft.EntityFrameworkCore;

namespace SchoolAPI
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

            //builder.Services.AddDbContext<SchoolContext>((DbContextOptionsBuilder options) =>
            //{
            //    string? connectionString = builder.Configuration.GetConnectionString("SchoolDb");
            //    options.UseSqlServer(connectionString);
            //});

            builder.Services.AddDbContext<SchoolContext>(options => 
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("SchoolDb")
                )
            );

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
