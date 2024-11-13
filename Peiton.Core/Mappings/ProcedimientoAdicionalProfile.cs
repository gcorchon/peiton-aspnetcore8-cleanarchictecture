using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ProcedimientoAdicionalProfile : Profile
{
    public ProcedimientoAdicionalProfile()
    {
        CreateMap<Ent.ProcedimientoAdicional, VM.ProcedimientosAdicionales.ProcedimientoAdicionalViewModel>();
    }
}