using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Validations;
using Talabat.Repository.Data;

namespace Talabat.APIs;
public class Program
    {
        public static async Task Main(string[] args)
        {
        

        var webApplicationBuilder = WebApplication.CreateBuilder(args);


            #region Configure services
            // Add services to the container.

            webApplicationBuilder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationBuilder.Services.AddEndpointsApiExplorer();
            webApplicationBuilder.Services.AddSwaggerGen();

        webApplicationBuilder.Services.AddDbContext<StoreContext>(options=>
        {
            options.UseSqlServer(webApplicationBuilder.Configuration.GetConnectionString("DefaultConnection"));
        });

            #endregion
            
        var app = webApplicationBuilder.Build();

        using var scope = app.Services.CreateScope();
        var Services = scope.ServiceProvider;
        var _dbContext = Services.GetRequiredService<StoreContext>();
        var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();
        try
        {
            await _dbContext.Database.MigrateAsync(); // Apply & Update Database
        }
        catch (Exception ex)
        {

            var Logger = LoggerFactory.CreateLogger<Program>();
            Logger.LogError(ex, "An error occurred during migration");
        }


        #region Kastrel Middleware
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            #endregion
            app.Run();
        }
    }

