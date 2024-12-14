using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class EscritoSucursalProfile : Profile
{
    public EscritoSucursalProfile()
    {
        CreateMap<VM.EscritosSucursales.GuardarEscritoSucursalRequest, Ent.EscritoSucursal>();
    }
}