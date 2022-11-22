using Microsoft.EntityFrameworkCore;
using MVCHome.Models;

namespace MVCHome.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Roles> Rol { get; set; }
        public DbSet<Articulo> Articulo { get; set; }
    }
}
