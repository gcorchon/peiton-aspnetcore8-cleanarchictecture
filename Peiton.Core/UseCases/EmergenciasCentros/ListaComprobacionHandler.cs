using Peiton.Contracts.EmergenciasCentros;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.EmergenciasCentros;

[Injectable]
public class ListaComprobacionHandler(IEmergenciaCentroRepository emergenciaCentroRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<CheckListItem[]> HandleAsync(int id)
    {
        var emergenciaCentro = await emergenciaCentroRepository.GetByIdAsync(id) ?? throw new NotFoundException("Emergencia no encontrada");
        if(!await tuteladoRepository.CanViewAsync(emergenciaCentro.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);

        if(emergenciaCentro.CheckList != null) {
            return emergenciaCentro.CheckList.Deserialize<CheckListItem[]>()!;
        } else {
            return [];
        }
    }
}