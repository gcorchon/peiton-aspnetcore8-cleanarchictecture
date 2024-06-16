namespace Peiton.Contracts.Consultas
{
    public class ActualizarConsultaRequest
    {
        public string Descripcion { get; set; } = string.Empty;
        public string? Resumen { get; set; }
        public int CategoriaId { get; set;}
        public IEnumerable<PermisoMini> Usuarios { get; set; } = new List<PermisoMini>();
    }
}
