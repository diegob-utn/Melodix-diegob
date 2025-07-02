namespace Melodix.Modelos
{
    public class HistorialEscucha
    {
        public int Id { get; set; }
        public DateTime EscuchadaEn { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? PistaId { get; set; }
        public Pista? Pista { get; set; }
    }
}