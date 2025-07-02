namespace Melodix.Modelos
{
    public class UsuarioLikeLista
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? ListaId { get; set; }
        public ListaReproduccion? Lista { get; set; }
    }
}