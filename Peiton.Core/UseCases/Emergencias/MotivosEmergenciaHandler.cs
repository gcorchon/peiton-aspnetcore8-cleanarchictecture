using Peiton.Contracts.Emergencias;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Emergencias;

[Injectable]
public class MotivosEmergenciaHandler(IMotivoEmergenciaRepository motivoEmergenciaRepository)
{
    public async Task<IEnumerable<MotivoEmergencia>> HandleAsync()
    {
        return await motivoEmergenciaRepository.GetManyAsync(v => v.Visible, v => v.Descripcion, "asc");
    }
}