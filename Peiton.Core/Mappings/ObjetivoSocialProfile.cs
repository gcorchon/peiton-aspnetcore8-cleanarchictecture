using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class ObjetivoSocialProfile : Profile
{
    public ObjetivoSocialProfile()
    {
        CreateMap<Ent.ObjetivoSocial, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, o => o.MapFrom(s => s.Id))
            .ForMember(vm => vm.Text, o => o.MapFrom(s => s.Descripcion));
    }
}