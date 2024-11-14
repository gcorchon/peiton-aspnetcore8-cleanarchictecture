using AutoMapper;
using Peiton.Contracts.SegurosAhorro;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SegurosAhorro;

[Injectable]
public class ActualizarSeguroAhorroHandler(IMapper mapper, ISeguroAhorroRepository SeguroAhorroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarSeguroAhorroRequest request)
    {
        var SeguroAhorro = await SeguroAhorroRepository.GetByIdAsync(id);
        if (SeguroAhorro == null) throw new EntityNotFoundException("Seguro de ahorro no encontrado");

        if (!await tuteladoRepository.CanModifyAsync(SeguroAhorro.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, SeguroAhorro);

        await unitOfWork.SaveChangesAsync();
    }
}