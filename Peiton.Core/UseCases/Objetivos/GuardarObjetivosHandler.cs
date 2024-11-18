
using AutoMapper;
using Peiton.Contracts.TuteladoObjetivos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Objetivos;

[Injectable]
public class GuardarObjetivosHandler(IMapper mapper, ITuteladoObjetivoRepository tuteladoObjetivoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int tuteladoId, int tipoObjetivoId, GuardarObjetivosRequest[] data)
    {
        if (!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var objetivos = await tuteladoObjetivoRepository.ObtenerObjetivosAsync(tuteladoId, tipoObjetivoId);

        for (var i = 0; i < data.Length; i++)
        {
            TuteladoObjetivo objetivo;
            if (objetivos.Length > i)
            {
                objetivo = objetivos[i];
            }
            else
            {
                objetivo = new TuteladoObjetivo
                {
                    TuteladoId = tuteladoId,
                    TipoObjetivoId = tipoObjetivoId
                };
                tuteladoObjetivoRepository.Add(objetivo);
            }

            mapper.Map(data[i], objetivo);
            objetivo.Orden = i + 1;
        }

        for (var j = data.Length; j < objetivos.Length; j++)
        {
            tuteladoObjetivoRepository.Remove(objetivos[j]);
        }

        await unitOfWork.SaveChangesAsync();
    }
}