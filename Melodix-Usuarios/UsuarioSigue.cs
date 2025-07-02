namespace Melodix_Usuarios
{
    public class UsuarioSigue
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public int SeguidorId { get; set; }
        public int SeguidoId { get; set; }
        public Usuario? Seguidor { get; set; }
        public Usuario? Seguido { get; set; }
    }
}