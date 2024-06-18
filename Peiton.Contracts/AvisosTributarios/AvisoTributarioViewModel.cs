namespace Peiton.Contracts.AvisosTributarios
{
    public class AvisoTributarioViewModel
    {
        public string TipoAvisoTributario { get; set; } = null!;
        public bool EnTramite { get; set; }
        public bool Resuelto { get; set; }
        public int? Ano { get; set;}
        public string? Inmueble { get; set; }
        public string? Comentarios { get; set;} = null!;
        public string? ComentariosDepartamentoTributario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime? FechaResolucion { get; set; }
    }
}
