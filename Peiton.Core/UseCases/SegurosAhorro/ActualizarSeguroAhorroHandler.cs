using AutoMapper;
using Peiton.Contracts.SegurosAhorro;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SegurosAhorro;

[Injectable]
public class ActualizarSeguroAhorroHandler(IMapper mapper, ISeguroAhorroRepository SeguroAhorroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarSeguroAhorroRequest request)
    {
        var SeguroAhorro = await SeguroAhorroRepository.GetByIdAsync(id);
        if (SeguroAhorro == null) throw new NotFoundException("Seguro de ahorro no encontrado");

        if (!await tuteladoRepository.CanModifyAsync(SeguroAhorro.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        mapper.Map(request, SeguroAhorro);

        await unitOfWork.SaveChangesAsync();
    }
}