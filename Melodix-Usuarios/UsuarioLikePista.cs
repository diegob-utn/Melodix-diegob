namespace Melodix_Usuarios
{
    public class UsuarioLikePista
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int UsuarioId { get; set; }
        public int PistaId { get; set; }
        public Usuario? Usuario { get; set; }
        public Pista? Pista { get; set; }
    }
}