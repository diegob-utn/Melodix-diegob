namespace Melodix_Usuarios
{
    public class HistorialLike
    {
        public int Id { get; set; }
        public string TipoObjetoLike { get; set; } = null!;
        public string AccionLike { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int ObjetoId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}