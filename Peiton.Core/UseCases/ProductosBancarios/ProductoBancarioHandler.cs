using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class ProductoBancarioHandler(IMapper mapper, ITuteladoRepository tuteladoRepository, IAccountRepository accountRepository, IFundRepository fundRepository, IDepositRepository depositRepository, IShareRepository shareRepository, IProductoManualRepository productoManualRepository)
{
    public async Task<ProductoBancarioViewModel> HandleAsync(int id, string tipo)
    {
        if (tipo == "manual")
        {
            var productoBancario = await productoManualRepository.GetByIdAsync(id) ?? throw new NotFoundException("Producto no encontrado");
            if (!await tuteladoRepository.CanViewAsync(productoBancario.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<ProductoBancarioViewModel>(productoBancario);
        }
        else if (tipo == "cuenta")
        {
            var account = await accountRepository.GetByIdAsync(id) ?? throw new NotFoundException("Libreta no encontrada");
            if (!await tuteladoRepository.CanViewAsync(account.Credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<ProductoBancarioViewModel>(account);
        }
        else if (tipo == "fondo")
        {
            var fund = await fundRepository.GetByIdAsync(id) ?? throw new NotFoundException("Fondo no encontrado");
            if (!await tuteladoRepository.CanViewAsync(fund.Credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<ProductoBancarioViewModel>(fund);
        }
        else if (tipo == "deposito")
        {
            var deposit = await depositRepository.GetByIdAsync(id) ?? throw new NotFoundException("Depósito no encontrado");
            if (!await tuteladoRepository.CanViewAsync(deposit.Credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<ProductoBancarioViewModel>(deposit);
        }
        else if (tipo == "cuenta-de-valores")
        {
            var share = await shareRepository.GetByIdAsync(id) ?? throw new NotFoundException("Cuenta de valores no encontrada");
            if (!await tuteladoRepository.CanViewAsync(share.Credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permisos para ver los datos de este tutelado");
            return mapper.Map<ProductoBancarioViewModel>(share);
        }

        throw new ArgumentException("Tipo de producto no válido (valores aceptados: manual, cuenta, fondo, deposito, cuenta-de-valores)");
    }
}