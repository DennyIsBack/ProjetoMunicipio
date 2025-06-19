using Microsoft.EntityFrameworkCore;
using ProjetoMunicipio.Model;

namespace ProjetoMunicipio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> opts)
            : base(opts) { }

        public DbSet<Municipio> Municipios { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Municipio>()
                   .ToTable("municipio")
                   .HasKey(m => m.CodMunicipio);

            base.OnModelCreating(builder);
        }
    }
}
