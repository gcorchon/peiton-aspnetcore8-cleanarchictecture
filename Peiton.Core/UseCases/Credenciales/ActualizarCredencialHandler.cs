using Peiton.Contracts.Credenciales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;

[Injectable]
public class ActualizarCredencialHandler(ICredencialRepository credencialRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, ActualizarCredencialRequest request)
    {
        var credencial = await credencialRepository.GetByIdAsync(id) ?? throw new NotFoundException("Credencial no encontrada");
        if (!await tuteladoRepository.CanModifyAsync(credencial.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar los datos del tutelado");

        credencial.EntidadFinancieraId = request.EntidadFinancieraId;
        credencial.DatosConexion = CredencialHelper.CodificarCampos(request.Campos);
        credencial.DetenerRobot = request.DetenerRobot;

        credencial.Reintentos = 0;
        credencial.DatosCorrectos = true;
        credencial.Baja = false;
        credencial.RequiereSMS = false;
        credencial.UltimaEjecucionCorrecta = null;
        credencial.UltimaEjecucion = null;
        credencial.ProximaEjecucion = null;

        await unitOfWork.SaveChangesAsync();
    }
}