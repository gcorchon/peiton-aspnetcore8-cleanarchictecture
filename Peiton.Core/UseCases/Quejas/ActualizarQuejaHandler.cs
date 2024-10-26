using AutoMapper;
using Peiton.Contracts.Quejas;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Quejas;

[Injectable]
public class ActualizarQuejaHandler(IQuejaRepository quejaRepository, IQuejaMotivoRepository quejaMotivoRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task HandleAsync(int quejaId, GuardarQuejaRequest request)
    {
        var queja = await quejaRepository.GetByIdAsync(quejaId);
        if (queja == null) throw new EntityNotFoundException("Gestión no encontrada");

        mapper.Map(request, queja);

        queja.QuejasMotivos.Merge(request.QuejaMotivos, c => c.Id, id => quejaMotivoRepository.GetById(id));

        await unitOfWork.SaveChangesAsync();
    }
}
