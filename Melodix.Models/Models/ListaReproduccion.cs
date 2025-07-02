namespace Melodix.Modelos
{
    public class ListaReproduccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Publica { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ActualizadoEn { get; set; }
        public string? Descripcion { get; set; }
        public string? SpotifyListaId { get; set; }
        public bool? Sincronizada { get; set; }
        public bool? Colaborativa { get; set; }
        public int? UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
        public List<ListaPista>? ListaPistas { get; set; }
        public List<UsuarioLikeLista>? UsuarioLikeListas { get; set; }
        public List<UsuarioSigueLista>? UsuarioSigueListas { get; set; }
    }
}