using AutoMapper;
using Peiton.Contracts.Requerimientos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Requerimientos;

[Injectable]
public class CrearRequerimientoHandler(IMapper mapper, IRequerimientoRepository requerimientoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(GuardarRequerimientoRequest request)
    {
        var requerimiento = mapper.Map(request, new Requerimiento());
        requerimiento.FechaRequerimiento = DateTime.Now;
        requerimientoRepository.Add(requerimiento);
        await unitOfWork.SaveChangesAsync();
    }
}