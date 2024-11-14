using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SeguroAhorroProfile : Profile
{
    public SeguroAhorroProfile()
    {
        CreateMap<Ent.SeguroAhorro, VM.SegurosAhorro.SeguroAhorroListItem>();
        CreateMap<VM.SegurosAhorro.CrearSeguroAhorroRequest, Ent.SeguroAhorro>();
        CreateMap<VM.SegurosAhorro.ActualizarSeguroAhorroRequest, Ent.SeguroAhorro>();
    }
}