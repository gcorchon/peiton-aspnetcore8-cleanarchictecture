using AutoMapper;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class ActualizarSenalamientoHandler(ISenalamientoRepository senalamientoRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task HandleAsync(int id, GuardarSenalamientoRequest request)
    {
        var senalamiento = await senalamientoRepository.GetByIdAsync(id);
        mapper.Map(request, senalamiento);
        await unitOfWork.SaveChangesAsync();
    }
}