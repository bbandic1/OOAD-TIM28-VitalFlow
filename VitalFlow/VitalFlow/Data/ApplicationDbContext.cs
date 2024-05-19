using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VitalFlow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            public DbSet<Korisnik> Korisnik { get; set; }
            public DbSet<Zahtjev> Zahtjev { get; set; }
            public DbSet<Termin> Termin { get; set; }
            public DbSet<Zahtjev_Hub> Zahtjev_Hub { get; set; }
            public DbSet<Termin_Hub> Termin_Hub { get; set; }
            public DbSet<Zaliha> Zaliha { get; set; }
            public DbSet<Hub> Hub { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<UpisNaPredmet>().ToTable("UpisNaPredmet");
            modelBuilder.Entity<Predmet>().ToTable("Predmet");
            base.OnModelCreating(modelBuilder);
        }
    }
    }
}
