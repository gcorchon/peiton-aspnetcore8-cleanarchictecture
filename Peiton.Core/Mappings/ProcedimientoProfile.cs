using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ProcedimientoProfile : Profile
{
    public ProcedimientoProfile()
    {
        CreateMap<Ent.Procedimiento, VM.Procedimientos.ProcedimientoViewModel>();
    }
}