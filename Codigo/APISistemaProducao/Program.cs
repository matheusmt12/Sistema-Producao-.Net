
using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using Service;

namespace APISistemaProducao
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

            //config database

            builder.Services.AddDbContext<SistemaProducaoContext>(
                options => options.UseMySQL(builder.Configuration.GetConnectionString("SistemaPDatabase"))
                );

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Add transient
            builder.Services.AddTransient<IClienteService, ClienteService>();

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
