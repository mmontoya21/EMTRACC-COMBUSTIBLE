using EmtraccWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace EmtraccWeb.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Comprobante> Comprobantes { get; set; }
    public DbSet<Acceso> Accesos { get; set; }
}
