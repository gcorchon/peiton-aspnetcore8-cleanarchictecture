using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.EmergenciasCentros;

[Injectable]
public class GuardarListaComprobacionHandler(IEmergenciaCentroRepository emergenciaCentroRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, CheckListItem[] request)
    {
        var emergenciaCentro = await emergenciaCentroRepository.GetByIdAsync(id) ?? throw new NotFoundException("Emergencia no encontrada");
        if(!await tuteladoRepository.CanViewAsync(emergenciaCentro.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        emergenciaCentro.CheckList = request.ToXDocument()!.ToString();
        await unitOfWork.SaveChangesAsync();
    }
}