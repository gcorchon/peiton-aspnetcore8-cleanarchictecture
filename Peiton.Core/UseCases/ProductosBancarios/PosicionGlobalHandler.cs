using System.Collections;
using AutoMapper;
using Peiton.Contracts.ProductosBancarios;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.ProductosBancarios;

[Injectable]
public class PosicionGlobalHandler(IMapper mapper, ITuteladoRepository tuteladoRepository)
{
    public async Task<IEnumerable<EntidadPosicionGlobalViewModel>> HandleAsync(int id)
    {
        var tutelado = await tuteladoRepository.GetByIdAsync(id) ?? throw new NotFoundException("Tutelado no encontrado");

        var entidades = new Dictionary<int, EntidadPosicionGlobalViewModel>();

        foreach (var credencial in tutelado.Credenciales)
        {
            if (!entidades.TryGetValue(credencial.EntidadFinancieraId, out EntidadPosicionGlobalViewModel? entidad))
            {
                entidad = new EntidadPosicionGlobalViewModel()
                {
                    CssClass = credencial.EntidadFinanciera.CssClass,
                    Descripcion = credencial.EntidadFinanciera.Descripcion
                };

                entidades.Add(credencial.EntidadFinancieraId, entidad);
            }

            entidad.Accounts = entidad.Accounts.Concat(mapper.Map<IEnumerable<ProductoBancarioPosicionGlobalViewModel>>(credencial.Accounts));
            entidad.Funds = entidad.Funds.Concat(mapper.Map<IEnumerable<ProductoBancarioPosicionGlobalViewModel>>(credencial.Funds));
            entidad.Deposits = entidad.Deposits.Concat(mapper.Map<IEnumerable<ProductoBancarioPosicionGlobalViewModel>>(credencial.Deposits));
            entidad.Shares = entidad.Shares.Concat(mapper.Map<IEnumerable<ProductoBancarioPosicionGlobalViewModel>>(credencial.Shares));

        }

        return entidades.Values;
    }
}