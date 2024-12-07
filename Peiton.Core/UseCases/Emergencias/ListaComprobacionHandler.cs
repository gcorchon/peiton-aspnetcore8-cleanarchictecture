using Peiton.Contracts.Emergencias;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Emergencias;

[Injectable]
public class ListaComprobacionHandler(IEmergenciaRepository emergenciaRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<CheckListItem[]> HandleAsync(int id)
    {
        var emergencia = await emergenciaRepository.GetByIdAsync(id) ?? throw new NotFoundException("Emergencia no encontrada");
        if(!await tuteladoRepository.CanViewAsync(emergencia.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        if(emergencia.CheckList != null) {
            return emergencia.CheckList.Deserialize<CheckListItem[]>()!;
        } else {
            return [];
        }
    }
}