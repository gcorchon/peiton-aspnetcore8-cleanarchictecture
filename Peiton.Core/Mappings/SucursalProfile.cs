using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SucursalProfile : Profile
{
    public SucursalProfile()
    {
        CreateMap<Ent.Sucursal, VM.Sucursales.SucursalListItem>();
        CreateMap<Ent.Sucursal, VM.Sucursales.SucursalViewModel>();
    }
}