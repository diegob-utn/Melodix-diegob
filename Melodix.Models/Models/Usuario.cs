namespace Melodix.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public RolUsuario Rol { get; set; }
        public bool Activo { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string? Proveedor { get; set; }
        public string? Biografia { get; set; }
        public string? FotoPerfil { get; set; }
        public string? Ubicacion { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string? SpotifyId { get; set; }
        public string? SpotifyTokenAcceso { get; set; }
        public string? SpotifyTokenRefresco { get; set; }
        public List<ListaReproduccion> ListasReproduccion { get; set; } = new();
        public List<HistorialEscucha> HistorialEscuchas { get; set; } = new();
        public List<UsuarioSigue> Seguidos { get; set; } = new();
        public List<UsuarioSigue> Seguidores { get; set; } = new();
        public List<UsuarioLikeAlbum> UsuarioLikeAlbums { get; set; } = new();
        public List<UsuarioLikeLista> UsuarioLikeListas { get; set; } = new();
        public List<UsuarioLikePista> UsuarioLikePistas { get; set; } = new();
        public List<UsuarioSigueArtista> UsuarioSigueArtistas { get; set; } = new();
        public List<UsuarioSigueLista> UsuarioSigueListas { get; set; } = new();
        public List<HistorialLike> HistorialLikes { get; set; } = new();
        public List<SuscripcionUsuario> SuscripcionUsuarios { get; set; } = new();
        public List<Suscripcion> Suscripciones { get; set; } = new();
    }
}