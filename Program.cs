using Taller_AE4.Data;
using Microsoft.EntityFrameworkCore;

namespace AE_4_RaulBenitez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<TallerContext>(op =>
            {
                string cadena = "Server=localhost;Database=tallercoches;Uid=root;Pwd=curso;";
                // le dice a EF cómo conectarse a la base de datos.
                op.UseMySql(cadena, ServerVersion.AutoDetect(cadena));
            });


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
                pattern: "{controller=Propietarios}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
