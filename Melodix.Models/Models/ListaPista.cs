namespace Melodix.Modelos
{
    public class ListaPista
    {
        public int Id { get; set; }
        public int? Posicion { get; set; }
        public DateTime? AgregadoEn { get; set; }
        public int? ListaId { get; set; }
        public ListaReproduccion? Lista { get; set; }
        public int? PistaId { get; set; }
        public Pista? Pista { get; set; }
    }
}