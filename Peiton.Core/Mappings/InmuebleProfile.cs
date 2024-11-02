using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class InmuebleProfile : Profile
{
    public InmuebleProfile()
    {
        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleInfo>();
        CreateMap<Ent.Inmueble, VM.Inmuebles.InmuebleSolicitudAlquilerVentaInfo>();
    }
}