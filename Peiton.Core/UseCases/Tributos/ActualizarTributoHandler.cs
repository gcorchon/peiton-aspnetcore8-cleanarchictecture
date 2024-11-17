using AutoMapper;

using Peiton.Contracts.Tributos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Tributos;

[Injectable]
public class ActualizarTributoHandler(IMapper mapper, ITributoTuteladoRepository tributoTuteladoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, TributoViewModel request)
    {
        var tributoTutelado = await tributoTuteladoRepository.GetByIdAsync(id);
        if (tributoTutelado == null) throw new NotFoundException("Tributo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(tributoTutelado.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, tributoTutelado);

        await unitOfWork.SaveChangesAsync();
    }
}