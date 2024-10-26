using AutoMapper;
using Peiton.Contracts.Capitulo;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Partidas;

[Injectable]
public class CreateCapituloHandler(IMapper mapper, IUnitOfWork unitOfWork, ICapituloRepository capituloRepository)
{
    public async Task HandleAsync(CreateCapituloRequest data)
    {
        var capitulo = mapper.Map(data, new Capitulo());
        await capituloRepository.AddAsync(capitulo);
        await unitOfWork.SaveChangesAsync();
    }
}
