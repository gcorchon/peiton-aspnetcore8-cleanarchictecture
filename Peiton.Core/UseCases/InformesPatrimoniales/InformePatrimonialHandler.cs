using Peiton.Contracts.InformesPatrimoniales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.InformesPatrimoniales;

[Injectable]
public class GenerarInformePatrimonialHandler(ITuteladoRepository tuteladoRepository, IDatosEconomicosRepository datosEconomicosRepository, ILoanRepository loanRepository,
            IAsientoRepository asientoRepository, IWordService wordService)
{
    public async Task<byte[]> HandleAsync(GenerarInformePatrimonialRequest request)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(request.TuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var datosJuridicos = tutelado.DatosJuridicos ?? throw new BusinessException("El tutelado no tiene datos jurídicos");
        var nombramiento = datosJuridicos.Nombramiento ?? throw new BusinessException("El tutelado no tiene un nombramiento");

        if(!nombramiento.CargoEconomico)
        {
            throw new BusinessException("El tutelado no tiene un cargo económico");
        }

        var fechaDesde = datosJuridicos.FechaJura.HasValue && datosJuridicos.FechaJura.Value > request.Desde ? datosJuridicos.FechaJura.Value : request.Desde;
        var fechaHasta = request.Hasta;

        var productos = await datosEconomicosRepository.ObtenerProductosRendicionAsync(request.TuteladoId, fechaDesde, fechaHasta);
        var prestamos = await loanRepository.ObtenerLoansParaRendicionAsync(request.TuteladoId, fechaDesde, fechaHasta);
        var utilizacionesExcluidas = new int[] { 11, 23 };
        var inmuebles = tutelado.Inmuebles.Where(inmueble => !utilizacionesExcluidas.Contains(inmueble.UtilizacionId)
                                && inmueble.InmueblesTiposTitularidades.FirstOrDefault()?.TipoTitularidad.Descripcion != "Ninguno").ToArray();
        var arrendamientos = tutelado.Arrendamientos.Where(a => a.FechaInicioArrendamiento.HasValue && a.FechaInicioArrendamiento.Value < fechaHasta && (!a.FechaFinArrendamiento.HasValue || a.FechaFinArrendamiento.Value > fechaDesde));
        var importeDeudas = (await asientoRepository.ObtenerIngresosYGastosFondoTuteladoAsync(request.TuteladoId, fechaHasta)).Diferencia;

        var categoriasExcluidas = new int[] { 41, 43, 97, 106, 143, 144, 152, 154, 174, 156, 148, 151, 107 };

        var justificacionIngresosYGastos = (await datosEconomicosRepository.ObtenerJustificaionIngresosYGastosAsync(request.TuteladoId, fechaDesde, fechaHasta)).ToArray();

        var diferenciaIngresosYGastos = request.SolicitarRetribucion ? (from row in justificacionIngresosYGastos
                                            where !categoriasExcluidas.Contains(row.CategoriaId)
                                            select row.Total).Sum() : 0;

        bool mostrarRetribucion = diferenciaIngresosYGastos > 0;

        if (mostrarRetribucion)
        {
            foreach (var linea in justificacionIngresosYGastos)
            {
                if (categoriasExcluidas.Contains(linea.CategoriaId))
                {
                    linea.Categoria = "(*) " + linea.Categoria;
                }
            }
        }

        var model = new InformePatrimonialViewModel
        {
            Tutelado = tutelado,
            FechaDesde = fechaDesde,
            FechaHasta = fechaHasta,
            Productos = productos,
            Inmuebles = inmuebles,
            Arrendamientos = arrendamientos,
            Prestamos = prestamos,
            ImporteDeudas = importeDeudas,
            JustificacionIngresosYGastos = justificacionIngresosYGastos,
            MostrarRetribucion = mostrarRetribucion,
            Retribucion = diferenciaIngresosYGastos
        };

        return await wordService.RenderRazorAsync("App_Data\\Plantillas\\Rendiciones\\informe-patrimonial.docx", model);
    }
    
}