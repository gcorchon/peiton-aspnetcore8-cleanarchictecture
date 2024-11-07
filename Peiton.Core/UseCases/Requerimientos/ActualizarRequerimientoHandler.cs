using AutoMapper;
using Peiton.Contracts.Requerimientos;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Requerimientos;

[Injectable]
public class ActualizarRequerimientoHandler(IMapper mapper, IRequerimientoRepository requerimientoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, GuardarRequerimientoRequest request)
    {
        var requerimiento = await requerimientoRepository.GetByIdAsync(id);
        if (requerimiento == null) throw new EntityNotFoundException("Requerimiento no encontrado");
        mapper.Map(request, requerimiento);
        await unitOfWork.SaveChangesAsync();
    }
}