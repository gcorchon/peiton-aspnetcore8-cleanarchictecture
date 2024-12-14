using Peiton.Contracts.ControlRendiciones;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ControlRendiciones;

[Injectable]
public class MarcarRetribucionContinuadaHandler(ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int tuteladoId, bool continuada)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        tutelado.RetribucionContinuada = continuada;
        await unitOfWork.SaveChangesAsync();
    }
}