using AutoMapper;
using Peiton.Contracts.EfectosPublicos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EfectosPublicos;

[Injectable]
public class ActualizarEfectoPublicoHandler(IMapper mapper, IEfectoPublicoRepository efectoPublicoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarEfectoPublicoRequest request)
    {
        var efectoPublico = await efectoPublicoRepository.GetByIdAsync(id);
        if (efectoPublico == null) throw new NotFoundException("Sueldo o pensión no encontrada");

        if (!await tuteladoRepository.CanModifyAsync(efectoPublico.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        mapper.Map(request, efectoPublico);

        await unitOfWork.SaveChangesAsync();
    }
}