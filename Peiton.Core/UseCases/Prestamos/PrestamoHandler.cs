using AutoMapper;
using Peiton.Contracts.Prestamos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Prestamos;

[Injectable]
public class PrestamoHandler(IMapper mapper, IPrestamoRepository prestamoRepository, ILoanRepository loanRepository, ITuteladoRepository tuteladoRepository)
{
    public async Task<PrestamoViewModel> HandleAsync(int id, string tipo)
    {
        if (tipo == "manual")
        {
            var prestamo = await prestamoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
            if (!await tuteladoRepository.CanViewAsync(prestamo.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<PrestamoViewModel>(prestamo);
        }
        else if (tipo == "robot")
        {
            var loan = await loanRepository.GetByIdAsync(id) ?? throw new NotFoundException("Préstamo no encontrado");
            if (!await tuteladoRepository.CanViewAsync(loan.Credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<PrestamoViewModel>(loan);
        }

        throw new ArgumentException("Tipo de préstamo no válido");
    }
}