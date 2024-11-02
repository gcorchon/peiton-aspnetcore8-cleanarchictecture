using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class SalaProfile : Profile
{
    public SalaProfile()
    {
        CreateMap<Ent.Sala, VM.Common.ListItem>()
            .ForMember(s => s.Value, opt => opt.MapFrom(s => s.Id))
            .ForMember(s => s.Text, opt => opt.MapFrom(s => s.Descripcion));

        CreateMap<Ent.Sala, VM.Salas.SalaListItem>();
    }
}