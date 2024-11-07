using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class RequerimientoTipoProfile : Profile
{
    public RequerimientoTipoProfile()
    {
        CreateMap<Ent.RequerimientoTipo, VM.Common.ListItem>();
    }
}