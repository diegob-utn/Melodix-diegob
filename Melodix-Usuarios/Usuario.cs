namespace Melodix_Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
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

        public List<UsuarioLikeAlbum>? UsuarioLikeAlbums { get; set; }
        public List<UsuarioLikeLista>? UsuarioLikeListas { get; set; }
        public List<UsuarioLikePista>? UsuarioLikePistas { get; set; }
        public List<UsuarioSigue>? Seguidores { get; set; }
        public List<UsuarioSigue>? Seguidos { get; set; }
        public List<HistorialLike>? HistorialLikes { get; set; }
    }
}