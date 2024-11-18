using Peiton.Contracts.Credenciales;
using Peiton.Core.Exceptions;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.Credenciales;
[Injectable]
public class CredencialBloqueadaHandler(ICredencialRepository credencialRepository)
{
    public async Task<IEnumerable<CampoCredencial>> HandleAsync(int id)
    {
        var credencial = await credencialRepository.GetByIdAsync(id) ?? throw new NotFoundException();
        return CredencialHelper.ObtenerCampos(credencial.EntidadFinanciera.Campos, credencial.DatosConexion);
    }
}