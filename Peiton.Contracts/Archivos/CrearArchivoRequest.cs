using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.Archivos;

public class CrearArchivoRequest : ActualizarArchivoRequest
{
    public int TuteladoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
}