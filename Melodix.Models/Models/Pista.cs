namespace Melodix.Modelos
{
    public class Pista
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string? Artista { get; set; }
        public string? Album { get; set; }
        public string? UrlPortada { get; set; }
        public DateTime? FechaLanzamiento { get; set; }
        public string? SpotifyPistaId { get; set; }
        public int? ArtistaId { get; set; }
        public Artista? ArtistaNav { get; set; }
        public List<ListaPista> ListaPistas { get; set; } = new();
        public List<HistorialEscucha> HistorialEscuchas { get; set; } = new();
        public List<UsuarioLikePista> UsuarioLikePistas { get; set; } = new();
    }
}