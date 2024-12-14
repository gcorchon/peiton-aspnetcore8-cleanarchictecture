using AutoMapper;
using Peiton.Contracts.EscritosSucursales;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EscritosSucursales;

[Injectable]
public class GuardarEscritosSucursalesHandler(IMapper mapper, IEscritoSucursalRepository escritoSucursalRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int tuteladoId, GuardarEscritoSucursalRequest[] request)
    {
        if (!await tuteladoRepository.CanModifyAsync(tuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var tutelado = await tuteladoRepository.GetByIdAsync(tuteladoId) ?? throw new NotFoundException("Tutelado no encontrado");
        var existentes = tutelado.EscritosSucursales.ToArray();
        var rellenos = request.Where(r => r.InformadaTutela.HasValue || r.PeticionClaves.HasValue || r.PrimeraSolicitud.HasValue || r.RecepcionClaves.HasValue || r.SegundaSolicitud.HasValue || r.SolicitudBloqueo.HasValue).ToArray();

        for (var i = 0; i < rellenos.Length; i++)
        {
            if (i < existentes.Length)
            {
                mapper.Map(rellenos[i], existentes[i]);
            }
            else
            {
                var escritoSucursal = mapper.Map(rellenos[i], new EscritoSucursal() { TuteladoId = tuteladoId });
                escritoSucursalRepository.Add(escritoSucursal);
            }
        }

        for (var i = rellenos.Length; i < existentes.Length; i++)
        {
            escritoSucursalRepository.Remove(existentes[i]);
        }

        await unitOfWork.SaveChangesAsync();
    }
}