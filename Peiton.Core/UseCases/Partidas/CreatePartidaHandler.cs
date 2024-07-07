using AutoMapper;
using Peiton.Contracts.Partida;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Partidas;

[Injectable]
public class CreatePartidaHandler(IMapper mapper, IUnityOfWork unityOfWork, ICapituloRepository capituloRepository)
{
    public async Task HandleAsync(int id, CreatePartidaRequest data)
    {
        var capitulo = await capituloRepository.GetByIdAsync(id);
        if (capitulo is null) throw new EntityNotFoundException($"No existe el capítulo con Id {id}");
        var partida = mapper.Map(data, new Partida());
        capitulo.Partidas.Add(partida);
        await unityOfWork.SaveChangesAsync();
    }
}
