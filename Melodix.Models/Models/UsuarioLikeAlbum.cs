namespace Melodix.Modelos
{
    public class UsuarioLikeAlbum
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? AlbumId { get; set; }
        public Album? Album { get; set; }
    }
}