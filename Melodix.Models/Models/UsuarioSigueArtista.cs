namespace Melodix.Modelos
{
    public class UsuarioSigueArtista
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? ArtistaId { get; set; }
        public Artista? Artista { get; set; }
    }
}