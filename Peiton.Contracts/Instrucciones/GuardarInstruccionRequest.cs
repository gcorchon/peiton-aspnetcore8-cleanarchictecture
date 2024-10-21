using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.Instrucciones;

public class GuardarInstruccionRequest
{
    public int CategoriaInstruccionId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
}