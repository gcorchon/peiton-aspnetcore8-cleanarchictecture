using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EfectosPublicos;

[Injectable]
public class BorrarEfectoPublicoHandler(IEfectoPublicoRepository efectoPublicoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id)
    {
        var efectoPublico = await efectoPublicoRepository.GetByIdAsync(id);
        if (efectoPublico == null) throw new NotFoundException("Efecto público no encontrado");

        if (!await tuteladoRepository.CanModifyAsync(efectoPublico.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        efectoPublicoRepository.Remove(efectoPublico);
        await unitOfWork.SaveChangesAsync();
    }
}