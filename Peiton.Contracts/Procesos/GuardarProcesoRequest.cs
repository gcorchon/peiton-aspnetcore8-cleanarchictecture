using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.Procesos;

public class GuardarProcesoRequest
{
    public int CategoriaProcesoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
    public string Descripcion { get; set; } = null!;
}