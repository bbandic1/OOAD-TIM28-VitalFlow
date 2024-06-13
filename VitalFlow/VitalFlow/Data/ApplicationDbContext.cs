using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Reflection.Emit;
using VitalFlow.Models;

namespace VitalFlow.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Zahtjev> Zahtjev { get; set; }
        public DbSet<Termin> Termin { get; set; }
        public DbSet<ZahtjevHub> Zahtjev_Hub { get; set; }
        public DbSet<TerminHub> Termin_Hub { get; set; }
        public DbSet<Zaliha> Zaliha { get; set; }
        public DbSet<HUB> Hub { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var krvnaGrupaConverter = new ValueConverter<KrvnaGrupa, string>(
                v => v.ToString().Replace("_Pozitivna", "+").Replace("_Negativna", "-"),
                v => Enum.Parse<KrvnaGrupa>(v.Replace("+", "_Pozitivna").Replace("-", "_Negativna"))
            );
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Zahtjev>().ToTable("Zahtjev");
            modelBuilder.Entity<Termin>().ToTable("Termin");
            modelBuilder.Entity<ZahtjevHub>().ToTable("ZahtjevHub");
            modelBuilder.Entity<TerminHub>().ToTable("TerminHub");
            modelBuilder.Entity<Zaliha>()
                .Property(z => z.krvnaGrupa)
                .HasConversion(krvnaGrupaConverter);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<HUB>().ToTable("Hub");
            base.OnModelCreating(modelBuilder);
        }

    }
}



