using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RecetasCocina_AE4.Datos;
using RecetasCocina_AE4.Datos.Repositorios;
using RecetasCocina_AE4.Models;
using RecetasCocina_AE4.Services;

var builder = WebApplication.CreateBuilder(args);

string cadena = "Server=localhost;Database=recetascocina;Uid=root;Pwd=curso;CharSet=utf8mb4;";
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(cadena, ServerVersion.AutoDetect(cadena)));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Auth/Login";
    options.AccessDeniedPath = "/Auth/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRecetaRepository, RecetaRepository>();
builder.Services.AddScoped<IIngredienteRepository, IngredienteRepository>();
builder.Services.AddScoped<IRecetasService, RecetasService>();
builder.Services.AddScoped<IIngredientesService, IngredientesService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
