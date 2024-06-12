using Express.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Express.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Kartica> Kartica { get; set; }
        public DbSet<Korpa> Korpa { get; set; }
        public DbSet<Proizvod> Proizvod { get; set; }
        public DbSet<Administrator> Administrator { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Kartica>().ToTable("Kartica");
            modelBuilder.Entity<Korpa>().ToTable("Korpa");
            modelBuilder.Entity<Proizvod>().ToTable("Proizvod");
            modelBuilder.Entity<Administrator>().ToTable("Zaposlenik");
        }
    }
}
