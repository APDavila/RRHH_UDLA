using Microsoft.EntityFrameworkCore;
using RecursosHumanos.API.Models;

namespace RecursosHumanos.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSet para las entidades
        public DbSet<Person> People { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Status> Statuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación entre Person y Gender
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderCode);

            // Configurar la relación entre Person y Status
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Status)
                .WithMany()
                .HasForeignKey(p => p.StatusCode);

            // Configurar la clave primaria de Gender
            modelBuilder.Entity<Gender>()
                .HasKey(g => g.Code);

            // Configurar la clave primaria de Status
            modelBuilder.Entity<Status>()
                .HasKey(s => s.Code);

            // Datos iniciales para Gender
            modelBuilder.Entity<Gender>().HasData(
                new Gender { Code = "M", Description = "Masculino" },
                new Gender { Code = "F", Description = "Femenino" },
                new Gender { Code = "N", Description = "No Binario" }
            );

            // Datos iniciales para Status
            modelBuilder.Entity<Status>().HasData(
                new Status { Code = "A", Description = "Activo" },
                new Status { Code = "I", Description = "Inactivo" }
            );
        }
    }
}