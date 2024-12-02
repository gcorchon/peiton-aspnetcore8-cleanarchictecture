using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.InformesPersonales;

public class ValidarInformePersonalRequest
{
    public int TuteladoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
}