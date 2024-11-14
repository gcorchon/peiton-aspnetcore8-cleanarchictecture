using AutoMapper;
using Peiton.Contracts.SegurosAhorro;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.SegurosAhorro;

[Injectable]
public class CrearSeguroAhorroHandler(IMapper mapper, ISeguroAhorroRepository SeguroAhorroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearSeguroAhorroRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var SeguroAhorro = mapper.Map(request, new SeguroAhorro());
        SeguroAhorroRepository.Add(SeguroAhorro);
        await unitOfWork.SaveChangesAsync();
    }
}