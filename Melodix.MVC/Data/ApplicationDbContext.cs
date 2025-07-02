using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Melodix.Modelos;

namespace Melodix.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioSigue> UsuarioSigue { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configuración de la relación muchos a muchos para UsuarioSigue
            modelBuilder.Entity<UsuarioSigue>()
                .HasOne(us => us.Seguidor)
                .WithMany(u => u.Seguidos)
                .HasForeignKey(us => us.SeguidorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UsuarioSigue>()
                .HasOne(us => us.Seguido)
                .WithMany(u => u.Seguidores)
                .HasForeignKey(us => us.SeguidoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
