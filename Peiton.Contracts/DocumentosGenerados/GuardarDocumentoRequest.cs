using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.DocumentosGenerados;

public class GuardarDocumentoRequest
{
    public int CategoriaDocumentoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
    public string Tags { get; set; } = null!;
}