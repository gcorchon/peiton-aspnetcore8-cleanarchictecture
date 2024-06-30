using Peiton.Contracts.Caja;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.CajasAMTA;

[Injectable]
public class GenerarDocumentoCajaAMTAHandler
{
    public Task HandleAsync(GuardarCajaAMTA data)
    {
        throw new NotImplementedException("Todavía no está generada la implementación del documento");
        //return Task.CompletedTask;
    }

}
