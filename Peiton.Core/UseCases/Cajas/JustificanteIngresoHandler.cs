using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Caja;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Cajas;

[Injectable]
public class JustificanteIngresoHandler(ITuteladoRepository tuteladoRepository, IWordService wordService, IIdentityService identityService, IOptions<AppSettings> appSettings)
{
    public async Task<byte[]> HandleAsync(JustificanteIngresoRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        return await wordService.RenderAsync($"App_Data\\Plantillas\\{appSettings.Value.Cliente}\\Caja\\Plantilla justificante Ingreso.docx", new Dictionary<string, string>(){
                {"[FECHA ACTUAL]", request.FechaAutorizacion.ToString("dd/MM/yyyy")},
                {"[TUTELADO]", tutelado.NombreCompleto!},
                {"[PERSONA]", request.PrestadorDelServicio ?? ""},
                {"[USUARIO]", await identityService.GetUserNameAsync()},
                {"[CONCEPTO]", request.Concepto},
                {"[DNI]", tutelado.DNI ?? ""},
                {"[IMPORTE]", request.Importe.ToString("N2")}
        });
    }
}