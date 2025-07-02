namespace Melodix_Usuarios
{
    public class UsuarioLikeLista
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int UsuarioId { get; set; }
        public int ListaId { get; set; }
        public Usuario? Usuario { get; set; }
        public ListaReproduccion? Lista { get; set; }
    }
}