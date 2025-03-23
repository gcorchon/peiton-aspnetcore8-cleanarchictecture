using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Contracts.CuentasGeneralesJustificadas;
using Peiton.Contracts.InformesPatrimoniales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.UseCases.AccountTransactions;
using Peiton.Core.UseCases.Archivos;
using Peiton.Core.UseCases.InformesPatrimoniales;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CuentasGeneralesJustificadas;

[Injectable]
public class GenerarCuentaGeneralJustificadaHandler(ITuteladoRepository tuteladoRepository, 
            IWordService wordService, IZipService zipService,
            ExportWordExtractoBancarioHandler exportWordExtractoBancarioHandler,
            GenerarInformePatrimonialHandler generarInformePatrimonialHandler,
            DescargarArchivoHandler descargarArchivoHandler, IOptions<AppSettings> options
            )
{
    public async Task<ArchivoViewModel> HandleAsync(GenerarCuentaGeneralJustificadaRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var datosJuridicos = tutelado.DatosJuridicos ?? throw new BusinessException("El tutelado no tiene datos jurídicos");
        var nombramiento = datosJuridicos.Nombramiento ?? throw new BusinessException("El tutelado no tiene un nombramiento");

        var fechaDesde = datosJuridicos.FechaJura.HasValue && datosJuridicos.FechaJura.Value > request.Desde ? datosJuridicos.FechaJura.Value : request.Desde;
        var fechaHasta = request.Hasta;

        byte[] cuentaGeneralJustificadaDocX;

        string plantilla = request.TipoCuentaGeneralJustificada switch {
                "CGJ Cese" => "CGJ-cese.docx",
                "CGJ Fallecimiento" => "CGJ-fallecim.docx",
                "CGJ Reintegración" => "CGJ-reintegracion.docx",
                _ => throw new NotImplementedException()
        };

        string cliente = options.Value.Cliente;
        
        var model = new CuentaGeneralJustificadaViewModel
        {
            Tutelado = tutelado,
            Desde = fechaDesde,
            Hasta = fechaHasta,
            LugarFallecimiento = request.LugarFallecimiento
        };

        var portadaDocX = await wordService.RenderRazorAsync($"App_Data\\Plantillas\\{cliente}\\CuentasGeneralesJustificadas\\{{plantilla}}", model);

        if (nombramiento.CargoEconomico)
        {            
            var informePatrimonialDocx = await generarInformePatrimonialHandler.HandleAsync(new GenerarInformePatrimonialRequest(){
                TuteladoId = request.TuteladoId,
                Desde = fechaDesde,
                Hasta = fechaHasta,
                SolicitarRetribucion = false
            }); 
            cuentaGeneralJustificadaDocX = await wordService.ConcatAsync(portadaDocX, informePatrimonialDocx);
        } else {
            cuentaGeneralJustificadaDocX = portadaDocX;
        }

        await zipService.AddFromDataAsync(plantilla, cuentaGeneralJustificadaDocX);

        if (nombramiento.CargoEconomico)
        {
            var extractoBancario = await exportWordExtractoBancarioHandler.HandleAsync(request.TuteladoId, fechaDesde, fechaHasta);
            await zipService.AddFromDataAsync("Documentos\\extracto-bancario.docx", extractoBancario);
        }

        foreach (var archivoId in request.Archivos)
        {
            try
            {
                var archivo = await descargarArchivoHandler.HandleAsync(archivoId);
                await zipService.AddFromDataAsync("Documentos\\" + archivoId + "_" + archivo.FileName, archivo.Data);
            }
            catch
            {

            }
        }

        var zipContents = zipService.Save();

        return new ArchivoViewModel()
        {
            Data = zipContents,
            FileName = $"rendicion anual {tutelado.NombreCompleto}.zip",
            MimeType = "application/zip"
        };
    }
}