using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class PosicionGlobalHandler(ICredencialRepository credencialRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<IEnumerable<Credencial>> HandleAsync(int tuteladoId)
    {
        if (!await tuteladoRepository.CanViewAsync(tuteladoId)) throw new NotFoundException(PeitonMessages.TUTELADO_NO_VIEW_ALLOWED);
        return await credencialRepository.ObtenerCredencialesAsync(tuteladoId);
    }
}