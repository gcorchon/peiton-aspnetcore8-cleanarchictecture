using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class GenerarJustificanteFondoSolidarioHandler(IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository, IWordService wordService, IOptions<AppSettings> appSettings)
{
    public async Task<ArchivoFondoSolidario> HandleAsync(int id)
    {
        var fondoSolidario = await fondoSolidarioRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo solidario no encontrado");

        if (!await tuteladoRepository.CanViewAsync(fondoSolidario.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver datos de este tutelado");

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

        return new ArchivoFondoSolidario()
        {
            Data = await wordService.RenderAsync(template, data),
            FileName = "justificante.docx",
            MimeType = "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
        };
    }
}