using AutoMapper;
using Peiton.Contracts.EfectosPublicos;
using Peiton.Core.Entities;
using Peiton.Core.Repositories;
using Peiton.DependencyInjection;

namespace Peiton.Core.UseCases.EfectosPublicos;

[Injectable]
public class CrearEfectoPublicoHandler(IMapper mapper, IEfectoPublicoRepository efectoPublicoRepository, ITuteladoRepository tuteladoRepository, IUnitOfWork unitOfWork)
{
    public async Task HandleAsync(CrearEfectoPublicoRequest request)
    {
        if (!await tuteladoRepository.CanModifyAsync(request.TuteladoId)) throw new UnauthorizedAccessException("No tienes permiso para modificar el tutelado");

        var efectoPublico = mapper.Map(request, new EfectoPublico());
        efectoPublico.Fecha = DateTime.Now;
        efectoPublicoRepository.Add(efectoPublico);
        await unitOfWork.SaveChangesAsync();
    }
}