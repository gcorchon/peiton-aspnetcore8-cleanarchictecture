using Peiton.Contracts.Caja;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.GestionMasiva;

[Injectable]
public class DocumentoArqueoHandler(ArqueoHandler arqueoHandler)
{
    public async Task<ArqueoModel> HandleAsync(DateTime fecha)
    {
        var arqueo = await arqueoHandler.HandleAsync(fecha);

        throw new NotImplementedException();
    }

}
