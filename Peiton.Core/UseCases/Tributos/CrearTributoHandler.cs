using AutoMapper;
using Peiton.Contracts.SueldosPensiones;
using Peiton.Contracts.Tributos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class CrearTributoHandler(IMapper mapper, ITributoTuteladoRepository tributoTuteladoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearTributoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var tributoTutelado = mapper.Map(request, new TributoTutelado());
        tributoTuteladoRepository.Add(tributoTutelado);
        await unitOfWork.SaveChangesAsync();
    }
}