using AutoMapper;
using Peiton.Contracts.FondosSolidarios;
using Peiton.Core.Entities;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.FondosSolidarios;

[Injectable]
public class CrearFondoSolidarioHandler(IMapper mapper, IIdentityService identityService, IFondoSolidarioRepository fondoSolidarioRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearFondoSolidarioRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);
        var fondo = mapper.Map(request, new FondoSolidario());
        fondo.FechaSolicitud = DateTime.Now;
        fondo.SolicitanteId = identityService.GetUserId();
        fondo.FechaCaducidad ??= DateTime.Today.AddMonths(6);
        fondoSolidarioRepository.Add(fondo);

        if (request.FondoSolidarioPadreId.HasValue)
        {
            var fondoPadre = await fondoSolidarioRepository.GetByIdAsync(request.FondoSolidarioPadreId.Value) ?? throw new NotFoundException("Registro de fondo original no encontrado");
            fondoPadre.FechaBaja = DateTime.Today;
        }

        await unitOfWork.SaveChangesAsync();
    }
}