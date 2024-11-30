using PruebaTecnica.Components;
using PruebaTecnica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Configurar AppDbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddHttpContextAccessor();

// Configurar autenticación con cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login"; // Ruta para la página de inicio de sesión
        options.AccessDeniedPath = "/acceso-denegado"; // Ruta para la página de acceso denegado
    });

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication(); // Middleware de autenticación
app.UseAntiforgery();    // Middleware de antifalsificación
app.UseAuthorization();  // Middleware de autorización

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
