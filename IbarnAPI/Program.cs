
using IbarnAPI.Common;
using IbarnAPI.Service.BankAccountService;
using Microsoft.Extensions.DependencyInjection;

namespace IbarnAPI
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
            builder.Services.AddSingleton<ICommonService, CommonService>();
            builder.Services.AddTransient<ICommonService, CommonService>();
            builder.Services.AddScoped<IBankingService, BankingService>();
            builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

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
