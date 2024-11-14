using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class VehiculoProfile : Profile
{
    public VehiculoProfile()
    {
        CreateMap<Ent.Vehiculo, VM.Vehiculos.VehiculoListItem>();
        CreateMap<VM.Vehiculos.CrearVehiculoRequest, Ent.Vehiculo>();
        CreateMap<VM.Vehiculos.ActualizarVehiculoRequest, Ent.Vehiculo>();
    }
}