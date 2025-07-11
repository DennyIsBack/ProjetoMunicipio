using Microsoft.EntityFrameworkCore;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opts)
        {
            opts.UseNpgsql(
                "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=maxlow15"
            );
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Municipio>()
                   .ToTable("municipios_ibge")
                   .HasKey(m => m.CodMunicipio);

            base.OnModelCreating(builder);
        }
    }
}
