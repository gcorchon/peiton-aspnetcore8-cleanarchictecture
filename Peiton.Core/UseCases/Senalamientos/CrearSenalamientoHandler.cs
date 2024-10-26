using AutoMapper;
using Peiton.Contracts.Senalamientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Senalamientos;

[Injectable]
public class CrearSenalamientoHandler(ISenalamientoRepository senalamientoRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task HandleAsync(GuardarSenalamientoRequest request)
    {
        var senalamiento = mapper.Map<Senalamiento>(request);
        await senalamientoRepository.AddAsync(senalamiento);
        await unitOfWork.SaveChangesAsync();
    }
}