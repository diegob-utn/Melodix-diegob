
namespace Melodix.Modelos
{
    public class Suscripcion
    {
        public int Id { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public int? PlanId { get; set; }
        public PlanSuscripcion? Plan { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public EstadoSuscripcion Estado { get; set; }
        public List<SuscripcionUsuario>? SuscripcionUsuarios { get; set; }
    }
}