using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class RequerimientoOrigenProfile : Profile
{
    public RequerimientoOrigenProfile()
    {
        CreateMap<Ent.RequerimientoOrigen, VM.Common.ListItem>();
    }
}