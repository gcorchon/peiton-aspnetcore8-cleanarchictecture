using Peiton.Contracts.Credenciales;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.Core.Utils;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class CrearCredencialHandler(ICredencialRepository credencialRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearCredencialRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException(PeitonMessages.TUTELADO_NO_MODIFICATION_ALLOWED);

        var credencial = new Credencial()
        {
            TuteladoId = request.TuteladoId,
            EntidadFinancieraId = request.EntidadFinancieraId,
            Reintentos = 0,
            DatosCorrectos = true,
            Baja = false,
            DetenerRobot = request.DetenerRobot,
            RequiereSMS = false,
            DatosConexion = CredencialHelper.CodificarCampos(request.Campos)
        };

        credencialRepository.Add(credencial);
        await unitOfWork.SaveChangesAsync();
    }
}