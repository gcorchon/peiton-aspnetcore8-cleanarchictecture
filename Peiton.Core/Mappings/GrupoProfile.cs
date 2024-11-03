using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class GrupoProfile : Profile
{
    public GrupoProfile()
    {
        CreateMap<Ent.Grupo, VM.Common.ListItem>()
            .ForMember(v => v.Text, opt => opt.MapFrom(g => g.Descripcion))
            .ForMember(v => v.Value, opt => opt.MapFrom(g => g.Id));


        CreateMap<Ent.Grupo, VM.Grupos.GrupoConUsuaios>();

        CreateMap<Ent.Grupo, VM.Grupos.GrupoViewModel>()
            .ForMember(v => v.Permisos, opt => opt.MapFrom(g => g.Permisos.Select(p => p.Id)));
    }
}