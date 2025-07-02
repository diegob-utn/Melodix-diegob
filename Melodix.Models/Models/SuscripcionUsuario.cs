namespace Melodix.Modelos
{
    public class SuscripcionUsuario
    {
        public int Id { get; set; }
        public int? SuscripcionId { get; set; }
        public Suscripcion? Suscripcion { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}