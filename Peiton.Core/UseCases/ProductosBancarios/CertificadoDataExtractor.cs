using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class CertificadoDataExtractor(ProductosBancariosHandler productosBancariosHandler,
    ITuteladoRepository tuteladoRepository,
    IAccountDailyBalanceRealRepository accountDailyBalancaRealRepository,
    IFundDailyInfoRepository fundDailyInfoRepository,
    IDepositDailyBalanceRepository depositDailyBalanceRepository,
    IShareDailyBalanceRepository shareDailyBalanceRepository)
{
    public async Task<CertificadoViewModel> HandleAsync(int tuteladoId, int entidadFinancieraId, DateTime fechaCertificado)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var cabeceraFileName = $"App_Data/cabecera_certificados/cabecera_certificado_{entidadFinancieraId}.txt";
        if (!File.Exists(cabeceraFileName)) throw new ArgumentException("La entidad financiera no tiene definida una cabecera");

        var datos = new CertificadoViewModel()
        {
            Tutelado = (tutelado.Sexo == "H" ? "D." : "Dña. ") + tutelado.NombreCompleto,
            DNI = tutelado.DNI ?? "DESCONOCIDO",
            Cabecera = await File.ReadAllTextAsync(cabeceraFileName)
        };

        var productosBancarios = await productosBancariosHandler.HandleAsync(tuteladoId);

        foreach (var productoBancario in productosBancarios.Where(p => !p.Manual && p.EntidadFinanciera.Id == entidadFinancieraId && (!p.FechaBaja.HasValue || p.FechaBaja.Value >= fechaCertificado)))
        {
            DailyBalance? dailyBalance = productoBancario.TipoProducto switch
            {
                "Libreta" => await accountDailyBalancaRealRepository.ObtenerBalanceAsync(productoBancario.Id, fechaCertificado),
                "Depósito" => await fundDailyInfoRepository.ObtenerBalanceAsync(productoBancario.Id, fechaCertificado),
                "Fondo" => await depositDailyBalanceRepository.ObtenerBalanceAsync(productoBancario.Id, fechaCertificado),
                "Cuenta de Valores" => await shareDailyBalanceRepository.ObtenerBalanceAsync(productoBancario.Id, fechaCertificado),
                _ => throw new Exception($"El tipo de producto {productoBancario.TipoProducto} no está soportado")
            };

            if (dailyBalance == null) continue;

            datos.Productos.Add(new ProductoCertificado()
            {
                Fecha = dailyBalance.FechaSaldo,
                Importe = dailyBalance.Saldo,
                Numero = productoBancario.Identificacion,
                Tipo = productoBancario.TipoProducto
            });
        }

        return datos;
    }
}