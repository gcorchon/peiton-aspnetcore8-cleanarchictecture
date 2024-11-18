using Peiton.Contracts.Asientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Asientos;

[Injectable]
public class CertificadoDeudaFondoTuteladoHandler(IAsientoRepository asientoRepository, ITuteladoRepository tuteladoRepository, IWordService wordService)
{
    public async Task<byte[]> HandleAsync(CertificadoIngresosGastosRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        var ingresosYGastos = await asientoRepository.ObtenerIngresosYGastosFondoTuteladoAsync(request.TuteladoId, request.Fecha);
        var deuda = Math.Abs(ingresosYGastos.Diferencia);
        return await wordService.RenderAsync("App_Data/certificado-deuda.docx", new Dictionary<string, string>() {
                                {"[NOMBRE TUTELADO] [APELLIDOS TUTELADO]", tutelado.NombreCompleto!},
                                {"[FECHA DEUDA]", request.Fecha.ToString("dd 'de' MMMM 'de' yyyy").ToLower()},
                                {"[IMPORTE DEUDA TOTAL]", deuda.ToString("N2")},
                                {"[FECHA ACTUAL]", DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy").ToLower()}
                            });
    }
}