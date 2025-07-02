namespace Melodix.Modelos
{
    public class Album
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public string? UrlPortada { get; set; }
        public string? SpotifyAlbumId { get; set; }
        public int? ArtistaId { get; set; }
        public Artista? Artista { get; set; }
        public List<Pista>? Pistas { get; set; }
        public List<UsuarioLikeAlbum>? UsuarioLikeAlbums { get; set; }
    }
}