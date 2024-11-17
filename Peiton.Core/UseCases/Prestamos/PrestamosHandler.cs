using AutoMapper;
using Peiton.Contracts.Prestamos;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Prestamos;

[Injectable]
public class PrestamosHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, ILoanRepository loanRepository)
{
    public async Task<IEnumerable<PrestamoListItem>> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        var prestamosManuales = mapper.Map<IEnumerable<PrestamoListItem>>(tutelado.Prestamos);
        //var prestamosRobot = mapper.Map<IEnumerable<PrestamoListItem>>(tutelado.Credenciales.SelectMany(c => c.Loans));
        var prestamosRobot = mapper.Map<IEnumerable<PrestamoListItem>>(await loanRepository.ObtenerLoansAsync(tuteladoId)); //<-- para evitar que tire una query por cada prestamo

        return prestamosManuales.Concat(prestamosRobot);
    }
}