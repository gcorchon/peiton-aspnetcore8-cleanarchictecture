using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class EfectoPublicoProfile : Profile
{
    public EfectoPublicoProfile()
    {
        CreateMap<Ent.EfectoPublico, VM.EfectosPublicos.EfectoPublicoListItem>();
        CreateMap<VM.EfectosPublicos.CrearEfectoPublicoRequest, Ent.EfectoPublico>();
        CreateMap<VM.EfectosPublicos.ActualizarEfectoPublicoRequest, Ent.EfectoPublico>();
    }
}