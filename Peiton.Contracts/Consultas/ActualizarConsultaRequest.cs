using Peiton.Contracts.Usuarios;

namespace Peiton.Contracts.Consultas
{
    public class ActualizarConsultaRequest
    {
        public string Descripcion { get; set; } = string.Empty;
        public string? Resumen { get; set; }
        public int CategoriaId { get; set;}
        public IEnumerable<UsuarioTipoMini> Usuarios { get; set; } = new List<UsuarioTipoMini>();
    }
}
