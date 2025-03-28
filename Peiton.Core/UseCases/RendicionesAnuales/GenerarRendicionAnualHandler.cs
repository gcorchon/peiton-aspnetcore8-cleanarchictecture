using Microsoft.Extensions.Options;
using Peiton.Configuration;
using Peiton.Contracts.Common;
using Peiton.Contracts.RendicionesAnuales;
using Peiton.Contracts.InformesPatrimoniales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.UseCases.AccountTransactions;
using Peiton.Core.UseCases.Archivos;
using Peiton.Core.UseCases.InformesPatrimoniales;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.RendicionesAnuales;

[Injectable]
public class GenerarRendicionAnualHandler(ITuteladoRepository tuteladoRepository, IDatosEconomicosRepository datosEconomicosRepository, 
            IInformePersonalRepository informePersonalRepository, IWordService wordService, IZipService zipService,
            ExportWordExtractoBancarioHandler exportWordExtractoBancarioHandler,
            GenerarInformePatrimonialHandler generarInformePatrimonialHandler,
            DescargarArchivoHandler descargarArchivoHandler, IOptions<AppSettings> options
            )
{
    public async Task<ArchivoViewModel> HandleAsync(GenerarRendicionAnualRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var datosJuridicos = tutelado.DatosJuridicos ?? throw new BusinessException("El tutelado no tiene datos jurídicos");
        var nombramiento = datosJuridicos.Nombramiento ?? throw new BusinessException("El tutelado no tiene un nombramiento");

        var fechaDesde = datosJuridicos.FechaJura.HasValue && datosJuridicos.FechaJura.Value > request.Desde ? datosJuridicos.FechaJura.Value : request.Desde;
        var fechaHasta = request.Hasta;

        byte[] rendicionDocX;

        if (nombramiento.CargoEconomico)
        {
            var categoriasExcluidas = new int[] { 41, 43, 97, 106, 143, 144, 152, 154, 174, 156, 148, 151, 107 };

            var justificacionIngresosYGastos = (await datosEconomicosRepository.ObtenerJustificaionIngresosYGastosAsync(request.TuteladoId, fechaDesde, fechaHasta)).ToArray();

            var diferenciaIngresosYGastos = request.SolicitarRetribucion ? (from row in justificacionIngresosYGastos
                                             where !categoriasExcluidas.Contains(row.CategoriaId)
                                             select row.Total).Sum() : 0;

            bool mostrarRetribucion = diferenciaIngresosYGastos > 0;

            string plantilla;

            string cliente = options.Value.Cliente;
            if (!new int[] { 3, 9, 19 }.Contains(nombramiento.Id))
                plantilla = mostrarRetribucion ? $"App_Data\\Plantillas\\{cliente}\\Rendiciones\\rendicionanual-con-retribucion.docx" :
                                                 $"App_Data\\Plantillas\\{cliente}\\Rendiciones\\rendicionanual.docx";
            else
                plantilla = mostrarRetribucion ? $"App_Data\\Plantillas\\{cliente}\\Rendiciones\\rendicionanual-con-retribucion-sin-informe-social.docx" :
                                                 $"App_Data\\Plantillas\\{cliente}\\Rendiciones\\rendicionanual-sin-informe-social.docx";

            var model = new RendicionViewModel
            {
                Tutelado = tutelado,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta,
                JustificacionIngresosYGastos = justificacionIngresosYGastos,
                MostrarRetribucion = mostrarRetribucion,
                Retribucion = diferenciaIngresosYGastos
            };

            var portadaDocX = await wordService.RenderRazorAsync(plantilla, model);
            
            var informePatrimonialDocx = await generarInformePatrimonialHandler.HandleAsync(new GenerarInformePatrimonialRequest(){
                TuteladoId = request.TuteladoId,
                Desde = fechaDesde,
                Hasta = fechaHasta,
                SolicitarRetribucion = request.SolicitarRetribucion
            }); 

            rendicionDocX = await wordService.ConcatAsync(portadaDocX, informePatrimonialDocx);
        }
        else
        {
            rendicionDocX = await wordService.RenderRazorAsync("App_Data\\Plantillas\\Rendiciones\\salud.docx", new RendicionBase
            {
                Tutelado = tutelado,
                FechaDesde = fechaDesde,
                FechaHasta = fechaHasta,
            });
        }

        await zipService.AddFromDataAsync("rendicion-anual.docx", rendicionDocX);

        var informePersonal = await informePersonalRepository.ObtenerUltimoInformePersonalAsync(request.TuteladoId);
        if (informePersonal != null)
        {
            await zipService.AddFromDataAsync("Documentos\\informe-personal.pdf", informePersonal.Informe);
        }

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