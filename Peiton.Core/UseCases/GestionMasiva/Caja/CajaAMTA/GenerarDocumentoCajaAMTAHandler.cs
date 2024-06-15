using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Core.Entities;
using Peiton.Contracts.Caja;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class GenerarDocumentoCajaAMTAHandler
{
    public async Task HandleAsync(GuardarCajaAMTA data)
    {
        throw new NotImplementedException("Todavía no está generada la implementación del documento");
        //return await Task.CompletedTask;
    }

}
