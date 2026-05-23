using MudBlazor.Services;
using GestorPagoProveedores.Components;
// Agregamos los namespaces para la base de datos
using Microsoft.EntityFrameworkCore;
using GestorPagoProveedores.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. CONFIGURACIÓN DE LA BASE DE DATOS (gestor.db)
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=gestor.db"));

// Add MudBlazor services
builder.Services.AddMudServices();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// 2. TRUCO DE INICIALIZACIÓN: Crea las tablas automáticamente al arrancar
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<AppDbContext>();
        context.Database.EnsureCreated(); // Esto creará las tablas vacías en gestor.db
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Ocurrió un error al inicializar la base de datos.");
    }
}

app.Run();