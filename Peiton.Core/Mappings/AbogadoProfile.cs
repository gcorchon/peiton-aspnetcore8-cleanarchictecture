using AutoMapper;
using Ent = Peiton.Core.Entities;
using VM = Peiton.Contracts;

namespace Peiton.Core.Mappings;
public class AbogadoProfile : Profile
{
    public AbogadoProfile()
    {
        CreateMap<Ent.Abogado, VM.Common.ListItem>()
            .ForMember(vm => vm.Value, m => m.MapFrom(o => o.Id))
            .ForMember(vm => vm.Text, m => m.MapFrom(o => o.Nombre));
    }
}