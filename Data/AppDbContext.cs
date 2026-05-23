using Microsoft.EntityFrameworkCore;

namespace GestorPagoProveedores.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Proveedor> Proveedores => Set<Proveedor>();
    public DbSet<Banco> Bancos => Set<Banco>();
}