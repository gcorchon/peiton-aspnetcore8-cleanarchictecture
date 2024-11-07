using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class RequerimientoDetalleProfile : Profile
{
    public RequerimientoDetalleProfile()
    {
        CreateMap<Ent.RequerimientoDetalle, VM.Common.ListItem>();
    }
}