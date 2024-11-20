using AutoMapper;
using Peiton.Contracts.Prestamos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Prestamos;

[Injectable]
public class ActualizarPrestamoRobotHandler(IMapper mapper, ILoanRepository loanRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarPrestamoRobotRequest request)
    {
        var loan = await loanRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
        if (!await tuteladoRepository.CanModifyAsync(loan.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        mapper.Map(request, loan);
        await unitOfWork.SaveChangesAsync();
    }
}