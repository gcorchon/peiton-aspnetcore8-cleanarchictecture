using AutoMapper;
using Peiton.Contracts.Common;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class ObtenerAbogadosParaSenalamientoHandler(ISenalamientoRepository senalamientoRepository, ITuteladoRepository tuteladoRepository, IMapper mapper)
{
    public async Task<AbogadoSenalamiento?> HandleAsync(int tuteladoId, DateTime fecha, int juzgadoId, int? senalamientoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId);

        if (tutelado == null) throw new NotFoundException("No existe el tutelado");

        var abogado = tutelado.Abogado;

        if (abogado == null) return new AbogadoSenalamiento() { AbogadoAsignado = null, AbogadoAsistente = null };

        bool libra = senalamientoId.HasValue ?
            await senalamientoRepository.EstaLibrandoAsync(abogado.Id, fecha, senalamientoId.Value) :
            await senalamientoRepository.EstaLibrandoAsync(abogado.Id, fecha);

        var abogadoListItem = mapper.Map<ListItem>(abogado);

        if (libra)
        {
            //El abogado no tiene juicio asignado ese día, así que puede ir
            return new AbogadoSenalamiento() { AbogadoAsignado = abogadoListItem, AbogadoAsistente = abogadoListItem };
        }

        bool mismoJuzgado = senalamientoId.HasValue ?
            await senalamientoRepository.TieneOtroCasoAsync(abogado.Id, fecha, juzgadoId, senalamientoId.Value) :
            await senalamientoRepository.TieneOtroCasoAsync(abogado.Id, fecha, juzgadoId);

        if (mismoJuzgado)
        {
            //El abogado tiene juicio asignado ese día en el mismo juzgado, así que puede ir
            return new AbogadoSenalamiento() { AbogadoAsignado = abogadoListItem, AbogadoAsistente = abogadoListItem };
        }
        else
        {
            var abogado2 = await senalamientoRepository.BuscarAbogadoDisponibleAsync(fecha);

            ListItem? abogado2ListItem = null;
            if (abogado2 != null)
            {
                abogado2ListItem = mapper.Map<ListItem>(abogado2);
            }

            return new AbogadoSenalamiento() { AbogadoAsignado = abogadoListItem, AbogadoAsistente = abogado2ListItem };
        }
    }
}