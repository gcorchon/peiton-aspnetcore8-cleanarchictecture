using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class ActualizarProductoBancarioRobotHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IAccountRepository accountRepository, IFundRepository fundRepository, IDepositRepository depositRepository, IShareRepository shareRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarProductoBancarioRobotRequest request)
    {
        if (request.TipoProductoId == 1)
        {
            var account = await accountRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta no encontrada");
            if (!await tuteladoRepository.CanModifyAsync(account.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
            mapper.Map(request, account);
            await unitOfWork.SaveChangesAsync();
        }
        else if (request.TipoProductoId == 2)
        {
            var fund = await fundRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo no encontrado");
            if (!await tuteladoRepository.CanModifyAsync(fund.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
            mapper.Map(request, fund);
            await unitOfWork.SaveChangesAsync();
        }
        else if (request.TipoProductoId == 3)
        {
            var deposit = await depositRepository.GetByIdAsync(id) ?? throw new NotFoundException("Depósito no encontrado");
            if (!await tuteladoRepository.CanModifyAsync(deposit.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
            mapper.Map(request, deposit);
            await unitOfWork.SaveChangesAsync();
        }
        else if (request.TipoProductoId == 4)
        {
            var share = await shareRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta de valores no encontrada");
            if (!await tuteladoRepository.CanModifyAsync(share.Credencial.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
            mapper.Map(request, share);
            await unitOfWork.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentOutOfRangeException("Tipo de producto no válido");
        }
    }
}