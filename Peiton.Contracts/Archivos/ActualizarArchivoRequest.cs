using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.Archivos;

public class ActualizarArchivoRequest
{
    public int CategoriaArchivoId { get; set; }
    public string Descripcion { get; set; } = null!;
    public string? Tags { get; set; } = null!;
    public bool TuAppoyo { get; set; }
}