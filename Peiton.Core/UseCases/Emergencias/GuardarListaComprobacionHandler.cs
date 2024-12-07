using Peiton.Contracts.Emergencias;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Emergencias;

[Injectable]
public class GuardarListaComprobacionHandler(IEmergenciaRepository emergenciaRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, CheckListItem[] request)
    {
        var emergencia = await emergenciaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Emergencia no encontrada");
        if(!await tuteladoRepository.CanViewAsync(emergencia.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        emergencia.CheckList = request.ToXDocument()!.ToString();
        await unitOfWork.SaveChangesAsync();
    }
}