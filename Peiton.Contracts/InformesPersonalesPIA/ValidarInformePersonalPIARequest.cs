using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.InformesPersonalesPIA;

public class ValidarInformePersonalPIARequest
{
    public int TuteladoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
}