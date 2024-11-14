using Peiton.Contracts.DatosEconomicosCajaFuerte;
using Peiton.Core.Repositories;
using Ent = Peiton.Core.Entities;
using Peiton.DependencyInjection;
using AutoMapper;

namespace Peiton.Core.UseCases.DatosEconomicosCajaFuerte;

[Injectable]
public class ActualizarDatosEconomicosCajaHandler(IMapper mapper, IDatosEconomicosCajaRepository datosEconomicosCajaRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(int id, DatosEconomicosCajaViewModel request)
    {
        var datos = await datosEconomicosCajaRepository.GetAsync(d => d.TuteladoId == id);
        if (datos == null)
        {
            datos = new Ent.DatosEconomicosCaja();
            datos.TuteladoId = id;
            datosEconomicosCajaRepository.Add(datos);
        }

        mapper.Map(request, datos);

        await unitOfWork.SaveChangesAsync();
    }
}