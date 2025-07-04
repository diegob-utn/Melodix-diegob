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




        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioSigue> UsuarioSigue { get; set; }
        public DbSet<ListaReproduccion> ListasReproduccion { get; set; }
        public DbSet<UsuarioLikeLista> UsuarioLikeListas { get; set; }
        public DbSet<UsuarioSigueLista> UsuarioSigueListas { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Pista> Pistas { get; set; }
        public DbSet<Artista> Artistas { get; set; }
        public DbSet<HistorialEscucha> HistorialEscuchas { get; set; }
        public DbSet<HistorialLike> HistorialLikes { get; set; }
        public DbSet<UsuarioLikeAlbum> UsuarioLikeAlbums { get; set; }
        public DbSet<UsuarioLikePista> UsuarioLikePistas { get; set; }
        public DbSet<UsuarioSigueArtista> UsuarioSigueArtistas { get; set; }
        public DbSet<SuscripcionUsuario> SuscripcionUsuarios { get; set; }
        public DbSet<Suscripcion> Suscripciones { get; set; }
        public DbSet<PlanSuscripcion> PlanesSuscripcion { get; set; }
        public DbSet<ListaPista> ListaPistas { get; set; }

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
