var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// AUTENTICACIÓN POR COOKIES
builder.Services.AddAuthentication("cookieAuth")
    .AddCookie("cookieAuth", opciones =>
    {
        opciones.LoginPath = "/Cuenta/Denegado";
        opciones.AccessDeniedPath = "/Cuenta/Denegado";
        opciones.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

builder.Services.AddAuthorization();

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
