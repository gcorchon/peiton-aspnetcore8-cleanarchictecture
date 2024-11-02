using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleAvisoCosteProfile : Profile
{
    public InmuebleAvisoCosteProfile()
    {
        CreateMap<Ent.InmuebleAvisoCoste, VM.Inmuebles.Coste>();
    }
}