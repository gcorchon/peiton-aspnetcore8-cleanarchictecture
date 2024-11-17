using Microsoft.AspNetCore.Http;

namespace Peiton.Contracts.FondosSolidarios;

public class GuardarArchivoFondoSolidarioRequest
{
    public int TuteladoId { get; set; }
    public IFormFile Archivo { get; set; } = null!;
}