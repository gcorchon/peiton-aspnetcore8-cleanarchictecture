using Peiton.Contracts.Caja;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;
using Peiton.Serialization;

namespace Peiton.Core.UseCases.Arqueos;

[Injectable]
public class GuardarArqueoHandler(IArqueoRepository arqueoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(DateTime fecha, ArqueoModel request)
    {
        var arqueo = await arqueoRepository.GetAsync(a => a.Fecha == fecha.Date);
        if (arqueo == null)
        {
            arqueo = new Arqueo()
            {
                Fecha = fecha
            };

            await arqueoRepository.AddAsync(arqueo);
        }

        arqueo.Datos = request.ToXDocument()!.ToString();

        await unitOfWork.SaveChangesAsync();
    }

}
