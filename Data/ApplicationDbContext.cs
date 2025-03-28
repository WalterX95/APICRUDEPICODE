using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Artista> Artisti { get; set; }
    public DbSet<Evento> Eventi { get; set; }
    public DbSet<Biglietto> Biglietti { get; set; }
}
