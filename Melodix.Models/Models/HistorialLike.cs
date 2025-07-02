namespace Melodix.Modelos
{
    public class HistorialLike
    {
        public int Id { get; set; }
        public TipoObjetoLike TipoObjetoLike { get; set; }
        public AccionLike AccionLike { get; set; }
        public DateTime Fecha { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? ObjetoId { get; set; }
    }
}