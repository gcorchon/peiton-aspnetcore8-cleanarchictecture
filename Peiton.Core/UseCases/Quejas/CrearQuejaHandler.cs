using AutoMapper;
using Peiton.Contracts.Quejas;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Quejas;

[Injectable]
public class CrearrQuejaHandler(IQuejaRepository quejaRepository, IQuejaMotivoRepository quejaMotivoRepository, IUnitOfWork unitOfWork, IMapper mapper)
{
    public async Task HandleAsync(GuardarQuejaRequest request)
    {
        var expediente = await quejaRepository.ObtenerSiguienteNumeroExpedienteAsync(request.QuejaTipoId);

        var queja = new Queja();

        mapper.Map(request, queja);

        queja.QuejasMotivos.Merge(request.QuejaMotivos, c => c.Id, id => quejaMotivoRepository.GetById(id));
        queja.Expediente = expediente;

        quejaRepository.Add(queja);
        await unitOfWork.SaveChangesAsync();
    }
}
