using Microsoft.EntityFrameworkCore;
using TorneoEsports.Data;
using TorneoEsports.Data.Repositorios;
using TorneoEsports.Data.Repositorios.Interfaces;
using TorneoEsports.Services;
using TorneoEsports.Services.Interfaces;

namespace TorneoEsports
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TorneoEsportsContext>(op =>
            {
                string cadena = "Server=localhost;Database=torneo_esports;Uid=root;Pwd=curso;CharSet=utf8mb4;";

                // Le dice a EF cómo conectarse con MySQL vía Pomelo
                op.UseMySql(cadena, ServerVersion.AutoDetect(cadena));
            });

            builder.Services.AddScoped<IJugadorRepository, JugadorRepository>();
            builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();
            builder.Services.AddScoped<IInformeService, InformeService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Informes}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
