using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class ProductosBancariosHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IAccountRepository accountRepository, IFundRepository fundRepository, IDepositRepository depositRepository, IShareRepository shareRepository)
{
    public async Task<IEnumerable<ProductoBancarioListItem>> HandleAsync(int tuteladoId)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");

        var productosBancariosManuales = mapper.Map<IEnumerable<ProductoBancarioListItem>>(tutelado.ProductosManuales);

        var accountsRobot = mapper.Map<IEnumerable<ProductoBancarioListItem>>(await accountRepository.ObtenerAccountsAsync(tuteladoId));
        var depositsRobot = mapper.Map<IEnumerable<ProductoBancarioListItem>>(await depositRepository.ObtenerDepositsAsync(tuteladoId));
        var fundsRobot = mapper.Map<IEnumerable<ProductoBancarioListItem>>(await fundRepository.ObtenerFundsAsync(tuteladoId));
        var sharesRobot = mapper.Map<IEnumerable<ProductoBancarioListItem>>(await shareRepository.ObtenerSharesAsync(tuteladoId));

        return accountsRobot.Concat(depositsRobot).Concat(fundsRobot).Concat(sharesRobot).Concat(productosBancariosManuales);
    }
}

