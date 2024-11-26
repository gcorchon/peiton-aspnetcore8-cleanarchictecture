using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class GenerarJustificanteFondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository, IWordService wordService, IOptions<AppSettings> appSettings)
{
    public async Task<ArchivoViewModel> HandleAsync(int id)
    {
        var fondoSolidario = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo solidario no encontrado");

        if (!await tuteladoRepository.CanViewAsync(fondoSolidario.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        string template = Path.Combine("App_Data/Plantillas", appSettings.Value.Cliente, "vale-fondo-solidario.docx");
        if (!File.Exists(template)) throw new ArgumentException("Plantilla no encontrada");

        Dictionary<string, string> data = new() {
            {"[FECHA]", fondoSolidario.FechaPago.HasValue ? fondoSolidario.FechaPago.Value.ToString("dd/MM/yyyy"): ""},
            {"[TUTELADO]", fondoSolidario.Tutelado.NombreCompleto!},
            {"[NIF]", fondoSolidario.Tutelado.DNI ?? ""},
            {"[IMPORTE]", fondoSolidario.Importe.ToString("N2")},
            {"[CONCEPTO]", fondoSolidario.FondoSolidarioDestino.Descripcion},
            {"[FORMA PAGO]", fondoSolidario.FondoSolidarioFormaPago != null? fondoSolidario.FondoSolidarioFormaPago.Descripcion : ""}
        };

        return new ArchivoViewModel()
        {
            Data = await wordService.RenderAsync(template, data),
            FileName = "justificante.docx",
            MimeType = MimeTypeHelper.Word
        };
    }
}