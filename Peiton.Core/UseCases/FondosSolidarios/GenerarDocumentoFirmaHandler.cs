using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class GenerarDocumentoFirmaHandler(ITuteladoRepository tuteladoRepository, IWordService wordService, IOptions<AppSettings> appSettings)
{
    public async Task<ArchivoViewModel> HandleAsync(int tuteladoId, string tipo)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        if (!new string[] { "titular", "familiar" }.Contains(tipo)) throw new ArgumentException("Tipo de plantilla incorrecto");
        string template = Path.Combine("App_Data/Plantillas", appSettings.Value.Cliente, "fondo-solidario", tipo + ".docx");
        if (!File.Exists(template)) throw new ArgumentException("Plantilla no encontrada");

        Dictionary<string, string> data = new() {
            {"[TTO]", tutelado.Sexo == "H" ? "D." : "Dña."},
            {"[NOMBRE COMPLETO]", tutelado.NombreCompleto!},
            {"[DNI]", tutelado.DNI ?? ""},
            {"[FECHA ACTUAL]", DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy").ToLower()}
        };

        return new ArchivoViewModel()
        {
            Data = await wordService.RenderAsync(template, data),
            FileName = "Firma Fondo Solidario " + tutelado.NombreCompleto + ".docx",
            MimeType = MimeTypeHelper.Word,
        };
    }
}