namespace Peiton.Contracts.Consultas
{
    public class ConsultaViewModel
    {
        public string Descripcion { get; set; } = string.Empty;
        public string? Resumen { get; set; }
        public int CategoriaId { get; set;}
        public IEnumerable<Permiso> Usuarios { get; set; } = new List<Permiso>();
    }
}
